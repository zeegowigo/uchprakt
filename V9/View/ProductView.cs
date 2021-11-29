using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using V9.Controller;
using V9.Model;
using zwfdos.Properties;

namespace V9.View
{
    public partial class ProductView : UserControl,IMaterialView
    {
        MaterialController _controller;
        Material material;
        public ProductView(Material _material)
        {
            InitializeComponent();
            material = _material;
        }

        public string MaterialTypeProperties 
        {
            get { return this.labelType.Text; }
            set { this.labelType.Text = value; }
        }
        public string Title {
            get { return this.labelTitle.Text; }
            set { this.labelTitle.Text = value; }
        }
        public double MinCount {
           // get { return double.Parse(this.minCount.Text); }
            set { this.minCount.Text ="Минимальное количество:"+value.ToString(); }
        }
        public double? CountInStock
        {
          //  get { return double.Parse(this.amount.Text); }
            set { this.amount.Text = value.ToString(); }
        }
        public ICollection<Supplier> Supliers { 
            get; 
            set; 
        }

        public void Clear()
        {
            imageMaterial.Image = null;
            labelType.Text =string.Empty;
            minCount.Text = string.Empty;
            labelSuplier.Text = string.Empty;
            amount.Text = string.Empty;
        }

        public void SetController(MaterialController controller)
        {
            _controller = controller;
        }

        public void Show(Material material)
        {
            if (material.Image!=null)
            {
                System.IO.FileStream fs = new System.IO.FileStream(Environment.CurrentDirectory+material.Image, System.IO.FileMode.Open);
                System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                fs.Close();
                imageMaterial.Image = img;
            }
            else
            {
                imageMaterial.Image = zwfdos.Properties.Resources.picture;
            }
            labelType.Text = material.MaterialTypeID;
            labelTitle.Text=material.Title;
            minCount.Text +=material.MinCount.ToString();
            string result = "";
            using (ModelDB db = new ModelDB())
            {
                List<ProductCostHistory> list = db.ProductCostHistory.Where(p=>p.ProductID.Equals(material.Title)).ToList();
                foreach (var item in list)
                {
                    result += item.ProductID + " ";
                }
            }
            labelSuplier.Text = result;
            amount.Text+= material.CountInStock.ToString();
            if (material.MinCount > material.CountInStock)
                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f19292");
            if (material.CountInStock > 3 * material.MinCount)
                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffba01");
            this.panel3.MouseClick += addActive;
            this.panel1.MouseClick += addActive;
            this.panel2.MouseClick += addActive;
        }

   
        private void addActive(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.DarkGreen;
            _controller.isActive = true;
            _controller.MainView.ChangeVisible();
        }

        public MaterialController getController()
        {
            return _controller;
        }
    }
}
