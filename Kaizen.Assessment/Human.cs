namespace Kaizen.Assessment
{
    public class Human: Person
    {
        public Human() : base()
        {

        }
        public Human(int height) : base(height)
        {

        }
        
        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;

        }
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}