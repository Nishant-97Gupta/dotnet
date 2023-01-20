namespace DAL;
using BOL;


public class DBManager{
   public List<Product> getallproduct(){
    
        using (var context = new CollectionContext())
        {
            var products=from prod in context.Products select prod;
            return products.ToList<Product>();
        }

   }
     public Product getbyid(int pid){
           using(var context=new CollectionContext()){
              Product product=context.Products.Find(pid);
              return product;
           }
     }




    public void Deletebyid(int pid)
    {
        using(var context = new CollectionContext())
        {
            context.Products.Remove(context.Products.Find(pid));
            context.SaveChanges();
        }
    }
    public Product insert(Product prod){
        using(var context=new CollectionContext())
        {
            context.Products.Add(prod);
            context.SaveChanges();
            return prod;
        }
    }
public Product update(Product prod){

     using(var context=new CollectionContext()){
          Product theprod=context.Products.Find(prod.pid);
          theprod.pname=prod.pname;
          theprod.price=prod.price;
          theprod.stock=prod.stock;
          context.SaveChanges();
       return theprod;
           
     }
}
}