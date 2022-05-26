﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a person's employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class: 
        //Title, SupervisoryLevel, Years of employment within the company

        //There are 4 components of a class definition
        // data fields (data members)
        // property
        // constructor
        // behaviour (method)

        //data fields
        // are storage areas in your class
        // these are treated as variables
        // these may be public, private, public readonly
        private string _Title;
        private double _Years;

        //property looks like a method but it is not a method
        //These are access techniques to retrieve or set data in
        // your class without directly touching the storage data field

        //A property is associated with a single instance of data
        //A property is public so it can be accessed by an outside user of the class.
        //A property MUST have a get
        //A property MAY have a set
        //if no set, the property is not changeable by the user; readonly
        // commonly used for calculated data of the class
        //the set can be either public or private
        //   public: the user can alter the contents of the data
        //   private: only code within the class can alter the contents of the data

        //fully implemented property needs:
        // a) a declared storage area (data field (variable))
        // b) a declared property signature (access return data type (rdt) propertyname)
        // c) a coded accessor (get) coding block : public
        // d) an optional coded mutator (set) coding block : can be public or private
        //      if the set is private the only way to place data into this property is
        //      via the constructor or a behaviour (method)
        
        // When to use the fully implemented property:
        // a) if you are storing the associate data in an explicitly declared data field
        // b) if you are doing validation on incoming data
        // c) creating a property that generates an output from other data sources
        //      within the class (read only property); this property would ONLY have a 
        //      accessor (get)

        public string Title
        {
            //a property is associated with a single piece of data
            get
            {
                //accessor: the get is refered to the accessor
                //the get "coding block" will return the contents of a data field(s)
                //the return has syntax of    return expression; (an expression can be anything in c#)
                return _Title;
            }
            set
            {
                //mutator
                //the set "coding block" recieved an incoming value and placed it into the associated data field
                //during the setting, you might wish to validate the incoming data
                //during the setting, you might wish to do some type of logical processing using
                //  the data to set another field
                //the incoming piece of data is referred to using the keyword "value"
                
                //ensure that the incoming data is not null or empty or just whitespace
                //string.IsNullOrWhiteSpace() is a method of the string class.
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                //data is considered valid. value is stored in the data member (variable) _Title
                _Title = value;
            }
        }
    
        //auto implemented property:
        //
        //these properties differ only in syntax
        //each property is responsible for a single piece of data
        //these properties DO NOT REFERENCE A DECLARED PRIVATE DATA MEMBER (private variables)
        //the system generates an internal storage area of the return data type
        //the system manages the internal storage for the accessor and mutator
        //THERE IS NO ADDITONAL LOGIC APPLIED TO THE DATA VALUE !!!!!!
        //  If you want to apply logic against your incoming data you will use a Fully Implemented Property. 
        //If you are just going to hang onto data, as is, then use an auto implemented property

        //using an enum for this field will automatically restrict the data values
        //  this property can contain

        //syntax access rdt propertyname {get; [private]  set;} [] <- sqaure brackets mean optional

        public SupervisoryLevel Level { get; set; }

        //Since we need validation for _Years, we need to use a fully implemented property
        
        public double Years
        {
            get { return _Years; }
            set 
            { 
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentOutOfRangeException($"Years value {value} is invalid. Must be 0 or greater");
                    throw new AggregateException();
                }
                _Years = value;
            }
        }

        //Review of contructors
        //constructors:
        //this is used to initialize the physical object (instance) during its creation
        //the result of creation is to ensure that the coder gets an instance in a valid
        //  "known state"
        //
        //if your class definition has NO constructor coded, then the data members and/or
        //  auto implemented properties are set to the C# default data type value
        //
        //You can code one or more constructors in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        //  CONSTRUCTORS USED BY THE CLASS !!!!
        //
        //genrally, if you are going to code your own construtor(s) you code two types
        // First one is refered to as the Default constructor: this constructor does NOT take in any parameters
        //                                                     this constructor mimics the default system constructor
        // Second one is refered to as the Greedy constructor: this constructor has a list of parameters, one for each property,
        //                                                     declared for incoming data
        //
        // ex: (),(a),(b),(c),(d), (a,b),(a,b)(a,d)... how many constructos can I have? 2 raise power of 4 = 16 constructors are possible
        // These are a lot of contructors so that is why we have two constructors, Default (takes no data) and Greedy (takes one for each property)
        // ex: (), (a,b,c,d)
        // [] square is optional
        // syntax: accesstype classname([list of parameters])
        // {
        //  constructor code block
        // }
        //
        //IMPORTANT: The constructor DOES NOT have a return datatype
        //           You DO NOT call a construtor directly, it is called using the 
        //              new command ex:    new classname(....);
        // Default constructor
        public Employment()
        {
            //constructor body
            // a) it can be empty: values will be set to C# defaults
            // b) you COULD assign literal values to your properties with this constructor
            
            // the values that you give your class data members/properties CAN be assigned
            //      directly to a data member.
            //HOWEVER: if you have validated properties, you SHOULD consider saving your
            //         data values via the property.
            //You CAN code your validation logic within your constructors BECUASE objects 
            //  run your constructor when it is created.
            //Placing your logic in the constructor could be done if your property has
            //  a private set OR if your public data member is a readonly data member
            //Private sets and readonly data members CAN NOT have their data altered directly

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        //Gready Constructor
        public Employment(string title, SupervisoryLevel level, double years = 0.0)
        {
            //constructor body
            // a) a parameter for each property 
            // b) you COULD code your validation in this constructor
            // c) validation for public readonly data members MUST be done here
            // d) validation for properties with a private set MUST be done here
            //      if not done in the property.
            
            //default parameters

            //WHY? it allows the programmer to use your constructor/method without having to
            // specify all arguments in the code to your constructor/method
            
            //Location: end of parameter list
            //How many: as many as you wish.
            //values for your default parameters MUST be a valid value.
            //position and order of specified default parameters are important when the
            //  program uses the contructor/method.
            //default parameters CAN be skipped, HOWEVER, you still must account for the 
            //  skipped parameter in your argument call list using commas
            //by giving the default parameter an argument value on the call, the constructor/method
            //  default value is overridden

            //syntax: datatype parametername = default value
            //example: years on this constructor is a default parameter.

            //example: skipped defaults (3 default parameters, second one skipped)
            //  ...(string requiredparameter, int requiredparameter, int default1 = 0,
            //          int default2 = 0, int default3 = 1)
            //
            //call: ...("required string", 25, 10, , 5) default2 was skipped

            Title = title;
            Level = level;
            Years = years; //eventually the data will be placed in _Years
        
        }

        //Behaviours (a.k.a. methods)

        //a behaviour is any method in your class
        //behaviours can be private (for use by the class only); public(for use by the outside user)
        //all rules about methods are in effect
        
        //a special method may be placed in your class to reflect the data stored by the
        //  instance (object) based on this class definition.
        //this method is part of the system software and can be overridden by your own
        //  version of the method.

        public override string ToString()
        {
            //this string is known as a "comma seperated values (csv)" string 
            //this string used the get; of the property
            return $"{Title},{Level},{Years}";
        }

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //this method, in this example would not be necessary as the access directly 
            //  to Level (property) is public ( set; )
            //HOWEVER: IF the Level property had a private set;, the outside user would NOT
            //  have direct access to changing the property.
            //THEREFORE: a method (besides the constructor) would need to be supplied to allow
            //  the outside user the ability to alter the property value (if they so desired)
            
            //this assignment used the set; of the property
            Level = level;
        }




    }
}
