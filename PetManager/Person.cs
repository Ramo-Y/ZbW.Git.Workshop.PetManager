namespace PetManager
{
    using System;
    using System.ComponentModel;

    // INFO: Das ist ein Kommentar
    public class Person
    {
        public Person()
        {
            this.Pets = new BindingList<Pet>();
        }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public BindingList<Pet> Pets { get; private set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (this.Lastname != null ? this.Lastname.GetHashCode() : 0);
                hash = hash * 23 + (this.Firstname != null ? this.Firstname.GetHashCode() : 0);
                hash = hash * 23 + (this.Pets != null ? this.Pets.GetHashCode() : 0);
                return hash;
            }
        }

        public static BindingList<Person> GetDemoData()
        {
            var ret = new BindingList<Person>();
            var person = new Person()
                             {
                                 Lastname = "Müller",
                                 Firstname = "Max"
                             };
            person.Pets.Add(
                new Pet(new DateTime(2011, 1, 1))
                    {
                        Name = "Cäsar",
                        Breed = "Kanarienvogel",
                    });
            person.Pets.Add(
                new Pet(new DateTime(2008, 2, 2))
                    {
                        Name = "Bello",
                        Breed = "Hund"
                    });
            ret.Add(person);

            person = new Person()
                         {
                             Lastname = "Doe",
                             Firstname = "John"
                         };
            person.Pets.Add(
                new Pet(new DateTime(2016, 1, 1))
                    {
                        Name = "Fleckli",
                        Breed = "Kaninchen"
                    });
            person.Pets.Add(
                new Pet(new DateTime(2017, 1, 1))
                    {
                        Name = "Hoppel",
                        Breed = "Kaninchen"
                    });
            person.Pets.Add(
                new Pet(new DateTime(2018, 1, 1))
                    {
                        Name = "Wau",
                        Breed = "Hund"
                    });
            ret.Add(person);

            return ret;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return Equals(obj, this);
            }

            var person = (Person)obj;
            return string.Equals(this.Lastname, person.Lastname) && string.Equals(this.Firstname, person.Firstname);
        }
    }
}