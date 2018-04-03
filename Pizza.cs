namespace Strategy
{
    public class Pizza
    {
        public Size Size { get; set; }
        public Crust Crust { get; set; }
        public decimal Price { get; set; }
    }

    public enum Size
    {
        SMALL, MEDIUM, LARGE
    }

    public enum Crust
    {
        THIN, REGULAR, STUFFED
    }
}
