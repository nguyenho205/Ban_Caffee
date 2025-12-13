using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Ban_Caffee.Models.Cart
{
    public class CartItem
    {
        public string? ProductId {get; set;}
        public decimal Price { get; set;}
        public string? ProductName{get; set;}
        public string? Img{get; set;}
        public string? Status{get; set;}
        public string? Decription{get; set;}
        public int Quantity{get; set;}
        public decimal Total
        {
            get
            {
                return Price*Quantity;
            }
        }
        MyDbContext db = new MyDbContext();
        public CartItem(string id)
        {
            Product pd=db.Products.FirstOrDefault(x=>x.ProductId==id);
            if (pd != null)
            {
                ProductId=pd.ProductId;
                ProductName=pd.ProductName;
                Price=pd.Price;
                Img=pd.Img;
                Status=pd.Status;
                Decription=pd.Decription;
                Quantity=1;
            }
        }


    }
}