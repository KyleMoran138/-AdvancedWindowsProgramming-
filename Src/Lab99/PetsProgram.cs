using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab99 {
    class PetsProgram {
        static void Main(string[] args) {
            Dog myDog = new Dog(PET_TYPE.Dog, (PET_COLOR.Black | PET_COLOR.White), "Bowser");
            Cat myCat= new Cat(PET_TYPE.Cat, PET_COLOR.White, "Kitty");
            Bird myBird = new Bird(PET_TYPE.Bird, PET_COLOR.Red, "Big Bird");
            Amphibian myFrog = new Amphibian(PET_TYPE.Amphibian, PET_COLOR.Green, "Froggy");


            Pet dog2 = new Dog(PET_TYPE.Dog, (PET_COLOR.Black), "King");
            Console.WriteLine(dog2);

            Pet[] myPets = new Pet[8];
            myPets[0] = myDog;
            myPets[1] = myCat;
            myPets[2] = myBird;
            myPets[3] = myFrog;
            myPets[4] = new Reptile(PET_TYPE.Reptile, (PET_COLOR.Brown), "");
            myPets[5] = new Dog(PET_TYPE.Dog, (PET_COLOR.Black | PET_COLOR.White), "Tipsy", "Boxer");
            myPets[6] = new Dog(PET_TYPE.Dog, (PET_COLOR.Brown), "Gypsy", "Mutt");

            foreach(Pet myPet in myPets) {
                if(myPet != (Pet)null) {
                    Console.WriteLine(myPet);
                }else {
                    Console.WriteLine("I am not yet a pet");
                }
            }
            Console.WriteLine("\n");

            char[] delimiterChars = { '.' };
            foreach(Pet myPet in myPets) {
                if(myPet is Dog) {
                    Dog thisDog = (Dog)myPet;
                    if (thisDog.DogsBreed == "Mutt") {
                        Console.WriteLine("\n Sorry we dont allow {0} in this apartment", thisDog.DogsBreed);
                    } else {
                        Console.WriteLine("\nWe charge extra for dogs of this breed ({0}) in this apartment.", thisDog.DogsBreed);
                    }
                }else if(myPet != (object)null) {
                    string sTypeWithClassInfo = myPet.GetType().ToString();
                    string[] strArray = sTypeWithClassInfo.Split(delimiterChars);
                    Console.WriteLine("\nDisplay type informatiomn (namespace.classname)");
                    Console.WriteLine("Namespace:{0}, Classname:{1}", strArray[0], strArray[1]);
                    string sType = sTypeWithClassInfo.Split(delimiterChars)[1];
                    Console.WriteLine("{0}s are ok.", sType);
                }
            }

            Console.WriteLine("Program has ended successfully.\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
