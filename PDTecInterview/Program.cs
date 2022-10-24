internal class Program
{
    private class Person
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Person? Father { get; set; }
        public Person? Mother { get; set; }
        public Person(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
        public Person(string? Name, string? Surname, Person? Father, Person? Mother)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Father = Father;
            this.Mother = Mother;
        }

        public static Person? Ancestor(Person? child, string? surname)
        {
            if (child == null)
                return null;
            if (child.Father != null && child.Father.Surname == surname)
                return child.Father;
            if (child.Mother != null && child.Mother.Surname == surname)
                return child.Mother;
            Person? person = Ancestor(child.Father, surname);
            if (person != null)
                return person;
            person = Ancestor(child.Mother, surname);
            if (person != null)
                return person;
            return null;
        }
    }

    private static void Main(string[] args)
    {
        List<Person> tree = new()
        {
            new Person("anna", "annabelle"),//tree[0]
            new Person("Adam", "Adam")//tree[1]
        };
        tree.Add(new Person("anna", "name", tree[0], tree[1]));//tree[2]
        tree.Add(new Person("Grandchild", "jacob", tree[2], null));//tree[3]
        Person? ancestor = Person.Ancestor(tree[2], "Adam");
        if (ancestor != null)
            Console.WriteLine(ancestor.Surname + " is an ancestor");
        else
            Console.WriteLine("ancestor not found");

        ancestor = Person.Ancestor(tree[3], "annabelle");
        if (ancestor != null)
            Console.WriteLine(ancestor.Surname + " is an ancestor");
        else
            Console.WriteLine("ancestor not found");
    }


}
