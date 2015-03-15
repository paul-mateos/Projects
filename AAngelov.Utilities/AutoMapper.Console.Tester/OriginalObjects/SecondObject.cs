namespace AutoMapper.Console.Tester.OriginalObjects
{
    public class SecondObject
    {
        public SecondObject(string firstNameS, string secondNameS, string poNumberS, decimal priceS)
        {
            this.FirstNameS = firstNameS;
            this.SecondNameS = secondNameS;
            this.PoNumberS = poNumberS;
            this.PriceS = priceS;
            ThirdObject1 = new ThirdObject();
            ThirdObject2 = new ThirdObject();
            ThirdObject3 = new ThirdObject();
            ThirdObject4 = new ThirdObject();
            ThirdObject5 = new ThirdObject();
            ThirdObject6 = new ThirdObject();
        }

        public SecondObject()
        {
        }

        public string FirstNameS { get; set; }
        public string SecondNameS { get; set; }
        public string PoNumberS { get; set; }
        public decimal PriceS { get; set; }
        public ThirdObject ThirdObject1 { get; set; }
        public ThirdObject ThirdObject2 { get; set; }
        public ThirdObject ThirdObject3 { get; set; }
        public ThirdObject ThirdObject4 { get; set; }
        public ThirdObject ThirdObject5 { get; set; }
        public ThirdObject ThirdObject6 { get; set; }
    }
}
