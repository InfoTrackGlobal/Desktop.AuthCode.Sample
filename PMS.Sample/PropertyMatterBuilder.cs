using System.Collections.Generic;

namespace PMS.Sample
{
    internal static class PropertyMatterBuilder
    {
        public static MatterDetail Construct(string clientReference, string retailerReference)
        {
            return new MatterDetail
            {
                ClientReference = clientReference,
                RetailerReference = retailerReference,
                PropertyDetails = new List<PropertyDetail>
                        {
                            new PropertyDetail
                                {
                                    PropertyAddress = new Address
                                        {
                                            StreetNumber = "15",
                                            StreetName = "Naples",
                                            StreetType = "Way",
                                            Suburb = "Pakenham",
                                            State = "VIC",
                                            PostCode = "3810",
                                            BuildingName = "Building Name",
                                            LotNumber = "1",
                                            StreetNumberTo = "2",
                                            UnitFlatShopNumber = "2"
                                        },
                                    Parish = "St Patricks",
                                    PurchasePrice = "sdf",
                                    PropertyReferences = new List<PropertyReference>
                                        {
                                            new PropertyReference
                                                {
                                                    Reference = "1863/1000001"
                                                }
                                        },
                                    LotPlans = new List<LotPlan>
                                        {

                                            new LotPlan
                                                {
                                                    Lot = "25",
                                                    PlanNumber = "98273",
                                                    Section = "992",
                                                    PlanType = "BUP"
                                                },
                                                new LotPlan
                                                {
                                                    Lot = "26",
                                                    PlanNumber = "98273",
                                                    Section = "992"
                                                }
                                        },
                                    CrownAllotment = new CrownAllotment
                                        {
                                            Section = "992"
                                        },
                                    Vendors = new List<PropertyEntity>
                                        {
                                            new PropertyEntity
                                                {
                                                    Individual = new Individual
                                                        {
                                                            GivenName = "Lorilea",
                                                            GivenName2 = "Mary",
                                                            Surname = "Donalds",
                                                        },
                                                    Address = new Address
                                                        {
                                                            StreetNumber = "27",
                                                            StreetName = "Railway",
                                                            StreetType = "Street",
                                                            Suburb = "Seymour",
                                                            State = "VIC",
                                                            PostCode = "3661"


                                                        }
                                                },
                                                new PropertyEntity
                                                {
                                                    Individual = new Individual
                                                        {
                                                            GivenName = "Jamy",
                                                            GivenName2 = "Nathan",
                                                            Surname = "Smith",
                                                            Title = "M."
                                                        },
                                                    Address = new Address
                                                        {
                                                            StreetNumber = "27",
                                                            StreetName = "NorthHead",
                                                            StreetType = "Street",
                                                            Suburb = "Sydney",
                                                            State = "NSW",
                                                            PostCode = "2000",
                                                            LotNumber = "1"
                                                        }
                                                }
                                        },
                                        AgentDetails = new List<AgentDetail>
                                        {
                                            new AgentDetail
                                                {
                                                    ContactDetails = new List<ContactDetail>
                                                        {
                                                            new ContactDetail
                                                                {
                                                                    Address = new Address
                                                                    {
                                                                        StreetNumber = "15",
                                                                        StreetName = "Naples",
                                                                        StreetType = "Way",
                                                                        Suburb = "Pakenham",
                                                                        State = "VIC",
                                                                        PostCode = "3810",
                                                                        BuildingName = "Building Name",
                                                                        LotNumber = "1",
                                                                        StreetNumberTo = "2",
                                                                        UnitFlatShopNumber = "2"
                                                                    },
                                                                    Phone = "02 657987987",
                                                                    Individual = new Individual
                                                                    {
                                                                        GivenName = "Billy"
                                                                    },
                                                                    PoBoxAddress = new PoBoxAddress
                                                                    {
                                                                        Instructions="Call me",
                                                                        Number = "2",
                                                                        PostCode = "2000",
                                                                        State = "NSW",
                                                                    },
                                                                    DxAddress = new DxAddress
                                                                    {
                                                                        Exchange = "",
                                                                        State = "NSW",
                                                                        Suburb = "Sydney",
                                                                        Number = "1"
                                                                    },
                                                                    Email = "info@infotrack.com.au",
                                                                    Fax = "0204654654",
                                                                }
                                                        }
                                                }
                                        },
                                       Area = "1024",
                                       Proprietors = new List<PropertyEntity>
                                        {
                                            new PropertyEntity
                                                {
                                                Individual   = new Individual
                                                    {
                                                        GivenName = "Smith"
                                                    },
                                                    Address = new Address
                                                        {
                                                            PostCode = "2000",
                                                            StreetName = "Kent",
                                                            StreetType = "Street"
                                                        },
                                                        Organisation = new Organisation
                                                        {
                                                            Name = "InfoTrack"
                                                            },
                                                            Email = "infotrack@infotrack.com.au",
                                                            Phone = "02 013216854"
                                                }
                                        },
                                        Purchasers = new List<PropertyEntity>
                                            {
                                                new PropertyEntity
                                                {
                                                    Individual = new Individual
                                                        {
                                                            GivenName = "Lorilea",
                                                            GivenName2 = "Mary",
                                                            Surname = "Donalds",
                                                        },
                                                    Address = new Address
                                                        {
                                                            StreetNumber = "27",
                                                            StreetName = "Railway",
                                                            StreetType = "Street",
                                                            Suburb = "Seymour",
                                                            State = "VIC",
                                                            PostCode = "3661"


                                                        }
                                                },
                                                new PropertyEntity
                                                {
                                                    Individual = new Individual
                                                        {
                                                            GivenName = "Jamy",
                                                            GivenName2 = "Nathan",
                                                            Surname = "Smith",
                                                            Title = "M."
                                                        },
                                                    Address = new Address
                                                        {
                                                            StreetNumber = "27",
                                                            StreetName = "NorthHead",
                                                            StreetType = "Street",
                                                            Suburb = "Sydney",
                                                            State = "NSW",
                                                            PostCode = "2000",
                                                            LotNumber = "1"
                                                        }
                                                }
                                            },
                                            OwnersCorporation = new OwnersCorporation
                                                {
                                                    ContactDetails = new List<ContactDetail>
                                                        {
                                                               new ContactDetail
                                                                {
                                                                    Address = new Address
                                                                    {
                                                                        StreetNumber = "15",
                                                                        StreetName = "Naples",
                                                                        StreetType = "Way",
                                                                        Suburb = "Pakenham",
                                                                        State = "VIC",
                                                                        PostCode = "3810",
                                                                        BuildingName = "Building Name",
                                                                        LotNumber = "1",
                                                                        StreetNumberTo = "2",
                                                                        UnitFlatShopNumber = "2"
                                                                    },
                                                                    Phone = "02 657987987",
                                                                    Individual = new Individual
                                                                    {
                                                                        GivenName = "Billy"
                                                                    },
                                                                    PoBoxAddress = new PoBoxAddress
                                                                    {
                                                                        Instructions="Call me",
                                                                        Number = "2",
                                                                        PostCode = "2000",
                                                                        State = "NSW",
                                                                    },
                                                                    DxAddress = new DxAddress
                                                                    {
                                                                        Exchange = "",
                                                                        State = "NSW",
                                                                        Suburb = "Sydney",
                                                                        Number = "1"
                                                                    },
                                                                    Email = "info@infotrack.com.au",
                                                                    Fax = "0204654654",
                                                                }
                                                        },
                                                        Organisation = new Organisation
                                                            {
                                                                 AcnOrAbn = "ACN",
                                                                 Name = "InfoTrack"
                                                            }
                                                },
                                                County = "County",
                                                Locality = "Locality",
                                                Council = "Council",
                                                VolumeFolios = new List<VolumeFolio>
                                                    {
                                                        new VolumeFolio
                                                            {
                                                                Folio = "23",
                                                                Volume = "4535"
                                                            },
                                                         new VolumeFolio
                                                            {
                                                                Folio = "24",
                                                                Volume = "4535"
                                                            },
                                                    },
                                                CouncilPropertyNumber = "2",
                                                MapReferences = new List<MapReference>
                                                    {
                                                        new MapReference
                                                        {
                                                            MapType = "Melways"//,
                                                            // Page = "488",
                                                            // Grid = "C7"
                                                        }
                                                    },
                                                Reason = "this is why",
                                },
                           },
                LawyerDetail = new LawyerDetail
                {
                    Organisation = new Organisation
                    {
                        AcnOrAbn = "ACN",
                        Name = "InfoTrack"
                    },
                    ContactDetails = new List<ContactDetail>
                    {
                        new ContactDetail
                        {
                            Address = new Address
                            {
                                StreetNumber = "27",
                                StreetName = "NorthHead",
                                StreetType = "Street",
                                Suburb = "Sydney",
                                State = "NSW",
                                PostCode = "2000",
                                LotNumber = "1"
                            },
                             DxAddress = new DxAddress
                             {
                                  Exchange = "",
                                  State = "NSW",
                                  Suburb = "Sydney",
                                  Number = "1"
                             },
                             Individual = new Individual
                             {
                                GivenName = "Roger"
                             },
                             PoBoxAddress= new PoBoxAddress
                             {
                                PostCode="2000"
                             }
                        },
                    }
                },
                Individuals = new List<Individual>
                    {
                        new Individual
                        {
                            GivenName = "Lorilea",
                            GivenName2 = "Mary",
                            Surname = "Donalds",
                        },
                        new Individual
                        {
                            GivenName = "Lorilea",
                            GivenName2 = "Mary",
                            Surname = "Donalds",
                        }
                    },
                Organisations = new List<Organisation>
                    {
                        new Organisation
                            {
                                AcnOrAbn = "ACN",
                                Name = "InfoTrack"
                            }
                    }
            };
        }
    }
}
