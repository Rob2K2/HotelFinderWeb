using MvcSiteMapProvider.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class HotelDynamicNodeProvider : DynamicNodeProviderBase
    {
        HotelFinderContext context = new HotelFinderContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection()
        {
            List<DynamicNode> returnList = new List<DynamicNode>();

            foreach (Hotel item in context.Photos)
            {
                DynamicNode newNode = new DynamicNode();
                newNode.Title = item.Name;
                newNode.ParentKey = "AllPhotos";
                newNode.RouteValues.Add("id", item.HotelID);
                returnList.Add(newNode);
            }

            return returnList;
        }
    }
}