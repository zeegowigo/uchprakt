using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V9.Model;

namespace V9.Controller
{
    public class AddEditController
    {
        IAddEditView _view;
        Material material;

        public AddEditController(IAddEditView view, Material material)
        {
            _view = view;
            this.material = material;
            _view.SetController(this);
        }

       
   
    public void addMaterialtoView()
        {
            _view.Title = material.Title;
            _view.CountInStock = material.CountInStock;
            _view.CountInPack = material.CountInPack;
            _view.Description = material.Description;
            _view.MinCount = material.MinCount;
            _view.Unit = material.Unit;
            _view.ImagePath = material.Image;
            _view.MaterialTypeId = material.MaterialTypeID;
        }

        public void LoadView()
        {
            _view.addMaterial(material);
        }
    }
}
