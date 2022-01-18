using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Images
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Extention { get; set; }

        public string Url { get; set; }
    }
}
