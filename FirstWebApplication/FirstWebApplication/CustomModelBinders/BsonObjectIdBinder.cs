using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using IModelBinder = System.Web.ModelBinding.IModelBinder;
using ModelBindingContext = System.Web.ModelBinding.ModelBindingContext;

namespace FirstWebApplication.CustomModelBinders
{
    public class BsonObjectIdBinder: System.Web.Mvc.IModelBinder
    {
        
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return new ObjectId(valueProviderResult.AttemptedValue);
        }
    }
}