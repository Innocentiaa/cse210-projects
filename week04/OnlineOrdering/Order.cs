public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer )
    {
        _customer = customer;
        _products = new List<Product>();
        
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = 0;
        foreach (var product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5 : 35;
        return productTotal + shippingCost;       
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label: \n";
        foreach (var product in _products)
        {
            label += product.GetPackingLabel() +"\n";
        }
        return label;
    }
    
    public string GetShippingLabel()
    {
        return "Shipping Label: \n" + _customer.GetShippingLabel();
    }
    
}