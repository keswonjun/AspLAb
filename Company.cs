namespace ASPnetlab1
{
    public class Company
    {
        public string Name { get; set; }
        public long StocksCount { get; set; }
        public float StocksPrice { get; set; }
        public int Employees { get; set; }
        public Company(string name, long stockscount, float stocksprice, int employees)
        {
            this.Name = name;
            this.StocksCount = stockscount;
            this.StocksPrice = stocksprice;
            this.Employees = employees;
        }
    }
}
