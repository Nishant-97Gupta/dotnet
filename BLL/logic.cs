namespace BLL;
using BOL;
using DAL;

public class logic
{
    public List<Product> productList(){
   List<Product> list=new List<Product>();
    DBManager mgr = new DBManager();
    list=mgr.getallproduct();
    foreach(Product item in list){
        Console.Write(item.pid);
         Console.Write(item.pname);
          Console.Write(item.price);
           Console.Write(item.stock);
    }
    return list;
    }
    public void Delete(int pid){
        DBManager mgr=new DBManager();
         mgr.Deletebyid(pid);
    }
     
public Product insertone(Product prod){
   DBManager mgr=new DBManager();
     Product saveprod=  mgr.insert(prod);
     return saveprod;
}

 public Product getone(int pid){
    DBManager mgr=new DBManager();
   Product uplist= mgr.getbyid(pid);
    return uplist;
 }
public Product updateprod(Product prod){
   DBManager mgr=new DBManager();
   Product updatelist=mgr.update(prod);
   return updatelist;

}

}
