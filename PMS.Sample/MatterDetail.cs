using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PMS.Sample
{
    internal class MatterDetail
    {
        [Required]
        [StringLength(50)]
        public string ClientReference { get; set; }

        [Required]
        public string RetailerReference { get; set; }
        public LawyerDetail LawyerDetail { get; set; }
        public List<PropertyDetail> PropertyDetails { get; set; }
        public List<Individual> Individuals { get; set; }
        public List<Organisation> Organisations { get; set; }
        public string MatterType { get; set; }
        public string EntryPoint { get; set; }
        public string State { get; set; }
        public List<CourtDetail> CourtDetails { get; set; }
        public User User { get; set; }
        // old LEAP token which is being used with old documents end point
        // we need to retire it 
        public string DocListToken { get; set; }
        //Smoke will pass docList and docDownload endpoint for retrieve and download 
        public string DocListEndPoint { get; set; }
        public string DocDownloadEndPoint { get; set; }

        // new auth token which can be used for LEAP Gateway API
        public string LeapAuthToken { get; set; }
        // LEAP refresh token (can be used for non LEAP too)
        public string LeapAuthRefreshToken { get; set; }

        public bool IsSecureMatter { get; set; }

        public List<Attachment> Attachments { get; set; }
        public string ExtraDetails { get; set; }

        public List<EntityDetail> Clients { get; set; }
        public List<EntityDetail> RegisteredAgents { get; set; }
        public List<EntityDetail> Incorporators { get; set; }

        public List<Address> RealEstateProperties { get; set; }
        public List<EntityDetail> Lawyers { get; set; }
        public LoanDetail LoanDetail { get; set; }

        public List<Share> Shares { get; set; }
        public Incorporation Incorporation { get; set; }

        public List<LawyerEntity> GetLawyers()
        {
            var results = Lawyers?.GroupBy(r => new { r.Organisation, r.Address })
                                                         .Select(grp => new LawyerEntity
                                                         {
                                                             Organisation = grp.Key.Organisation,
                                                             Address = grp.Key.Address,
                                                             Individuals = grp.Select(r => new EntityDetailIndividual

                                                             {
                                                                 FirstName = r.FirstName,
                                                                 LastName = r.LastName,
                                                                 Title = r.Title,
                                                                 Phone = r.Phone,
                                                                 Email = r.Email
                                                             }).ToList()
                                                         }).ToList() ?? new List<LawyerEntity>();

            foreach (var lawyer in results)
            {
                lawyer.DisplayName = string.IsNullOrWhiteSpace(lawyer.Organisation.Name)
                                                          ? $"{lawyer.Individuals[0].FirstName} {lawyer.Individuals[0].LastName}"
                                                                                 : lawyer.Organisation.Name;
            }

            return results;
        }

        public string PreAuthAmount { get; set; }

        public StockCertificate StockCertificate { get; set; }

        public string MatterName { get; set; }
    }

    public class PropertyDetail
    {
        public Address PropertyAddress { get; set; }
        public string Locality { get; set; }
        public string Council { get; set; }
        public string County { get; set; }
        public string Parish { get; set; }
        public string NatureOfProperty { get; set; }
        public string DocsPropertyReferences { get; set; } //Docs Only 
        public List<PropertyReference> PropertyReferences { get; set; }
        public List<LotPlan> DocsLotPlans { get; set; } //Docs Only 
        public List<LotPlan> LotPlans { get; set; }
        public string LotPlan { get; set; }
        public string DocsVolumeFolios { get; set; } //Docs Only 
        public List<VolumeFolio> VolumeFolios { get; set; }
        public string CouncilPropertyNumber { get; set; }
        public string Spi { get; set; }
        public CrownAllotment CrownAllotment { get; set; }
        public List<PropertyEntity> Proprietors { get; set; }
        public List<PropertyEntity> Vendors { get; set; }
        public List<PropertyEntity> VendorsSolicitors { get; set; }
        public List<PropertyEntity> Purchasers { get; set; }
        public List<PropertyEntity> PurchasersSolicitors { get; set; }

        public List<PropertyEntity> OtherParties { get; set; }

        public string ExchangeDate { get; set; }
        public string SettlementDate { get; set; }
        public string SettlementTime { get; set; }
        public string AreaUnit { get; set; }
        public string Area { get; set; }
        public string Reason { get; set; }
        public string PurchasePrice { get; set; }
        public string DepositPrice { get; set; }
        public string BalancePrice { get; set; }
        /// <summary>
        /// EDR Number for Stamp Duty
        /// </summary>
        public string Duty { get; set; }
        public List<MapReference> MapReferences { get; set; }
        public List<AgentDetail> AgentDetails { get; set; }
        public List<AgentDetail> PurchasersAgentDetails { get; set; }
        public List<AgentDetail> CoAgentDetails { get; set; }
        public List<AgentDetail> PurchasersAgents { get; set; }
        public OwnersCorporation OwnersCorporation { get; set; }

        public string PropertyFullAddress { get; set; }
        public ECOS ECOS { get; set; }
        public EDR EDR { get; set; }
        public S32VendorStatement S32VendorStatement { get; set; }
        public ENOS ENOS { get; set; }
        public LoanDetail LoanDetail { get; set; }
        public string ElnoId { get; set; }
    }

    public class DocsReference
    {
        public List<string> Reference;
    }

    public class LotPlan
    {
        public string Lot { get; set; }
        public string PlanType { get; set; }
        public string PlanNumber { get; set; }
        public string Section { get; set; }
        public string Block { get; set; }
        public string StageNumber { get; set; }
        public string RedevelopmentNumber { get; set; }
        public string TitleReference { get; set; }
        public string SubFolio { get; set; }
    }

    public class OwnersCorporation
    {
        public Organisation Organisation { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
    }

    public class VolumeFolio
    {
        public string Volume { get; set; }
        public string Folio { get; set; }
    }

    public class AgentDetail
    {
        public Organisation Organisation { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
        public string Reference { get; set; }
    }

    public class MapReference
    {
        public string MapType { get; set; }
        public string Page { get; set; }
        public string Grid { get; set; }
    }

    public class PropertyEntity
    {
        public PartyType PartyType { get; set; }
        public Individual Individual { get; set; }
        public Organisation Organisation { get; set; }
        public Address Address { get; set; }
        public Address FutureAddress { get; set; }
        public string Phone { get; set; }
        public string PhoneAreaCode { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Reference { get; set; }
        /// <summary>
        /// Options:
        /// "S": Sole Tenant
        /// "JT": Joint Tenant
        /// "TC": Tenant in Common
        /// </summary>
        public string TenancyIndicator { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string ActingAsTrustee { get; set; }
    }

    public enum PartyType
    {
        Undefined,
        Donor,
        RealEstateAgent,
        Witness,
        Beneficiary
    }

    public class CrownAllotment
    {
        public string Allotment { get; set; }
        public string Block { get; set; }
        public string Section { get; set; }
        public string Portion { get; set; }
        public string SubDivision { get; set; }
        public string Parish { get; set; }
    }

    public class PropertyReference
    {
        public string Reference { get; set; }
    }

    public class LawyerDetail
    {
        public Organisation Organisation { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
    }

    public class Organisation
    {
        public string Name { get; set; }
        public string AcnOrAbn { get; set; }
        public string Acn { get; set; }
        public string Abn { get; set; }

        public string BusinessType { get; set; }
        //This field is usually the Owner's last name when there's no organization name
        public string ShortName { get; set; }
        public string CompanyOrOwnerName { get; set; }
        public string CompanyTitle { get; set; }
    }

    public class Incorporation
    {
        public string ManageBy { get; set; }
        public string CompanyType { get; set; }
        public string NamePreference1 { get; set; }
        public string NamePreference2 { get; set; }
        public string NamePreference3 { get; set; }
        public string Description { get; set; }
    }

    public class Share
    {
        public string Class { get; set; }
        public int NumberOfAuthorizedShares { get; set; }
        public int IssuedShares { get; set; }
        public decimal? ParValue { get; set; }
        public decimal PaidInCapital { get; set; }
    }


    public class ContactDetail
    {
        public Individual Individual { get; set; }
        public Address Address { get; set; }
        public PoBoxAddress PoBoxAddress { get; set; }
        public DxAddress DxAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
    }

    public class PoBoxAddress
    {
        public string PoBoxType { get; set; }
        public string Number { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Instructions { get; set; }
    }

    public class Individual
    {
        public string Title { get; set; }
        public string GivenName { get; set; }
        public string GivenName2 { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfDeath { get; set; }
        public string FormerSurname { get; set; }
        public string IsAUCitizen { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string DriversLicenseNumber { get; set; }
    }

    public class Address
    {
        public string BuildingName { get; set; }
        public string LotNumber { get; set; }
        public string FloorNo { get; set; }
        public string UnitFlatShopNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetNumberTo { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string StreetAddress3 { get; set; }
        public string StreetAddress4 { get; set; }
        public string StreetAddress5 { get; set; }
        public string StreetAddress6 { get; set; }



        public string GetStreetAddress()
        {
            var buildingName = string.IsNullOrWhiteSpace(BuildingName) ? "" : BuildingName.Trim() + ", ";
            var streetNo = string.IsNullOrEmpty(StreetNumber) ? "" : StreetNumber.Trim() + " ";
            return string.IsNullOrEmpty(StreetAddress1) ? $"{buildingName}{streetNo}{StreetName}".Trim() : StreetAddress1;
        }

        public string GetStreetAddress2()
        {
            return string.IsNullOrWhiteSpace(StreetAddress2) ? string.IsNullOrWhiteSpace(UnitFlatShopNumber) ? "" : $"#{UnitFlatShopNumber}" : StreetAddress2;
        }
    }

    public class DxAddress
    {
        public string Number { get; set; }
        public string Exchange { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
    }

    public class CourtDetail
    {
        public List<Party> FillingParties { get; set; }
        public List<Party> AgainstParties { get; set; }
        public EstateDetails EstateDetails { get; set; }
        public List<string> CourtsList { get; set; }
        public string CaseNumber { get; set; }
        public string RegistryCourt { get; set; }
        public string RegistryLocation { get; set; }
        public string LawyerPcn { get; set; }
        public string ClaimAmount { get; set; }
        public string SolicitorFeeIncGST { get; set; }
        public string FilingCosts { get; set; }
        public string DocumentServiceFee { get; set; }
        public string Interest { get; set; }
        public string CourtsListType { get; set; }
        public string Description { get; set; }
        public string NatureOfClaim { get; set; }
        public string OrderSought { get; set; }
        public string PleadingDetails { get; set; }
        public List<string> AdditionalEmailContacts { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentTime { get; set; }
        public string IncidentLocation { get; set; }
        public string IncidentLocationSuburb { get; set; }
    }

    public class EstateDetails
    {
        public decimal GrossValueOfEstate { get; set; }
    }

    public class Party
    {
        public Individual Individual { get; set; }
        public Organisation Organisation { get; set; }
        public Address Address { get; set; }
        public PoBoxAddress PoBoxAddress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RoleSequence { get; set; }
        public string ClaimServedDate { get; set; }
        public List<LawyerDetail> Lawyers { get; set; }
    }

    public class User
    {
        public string Branch { get; set; }

        //[StringLength(50, MinimumLength = 1)]
        // [Required]
        public string UserFullName { get; set; }

        // [Required]
        //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = @"Please enter a valid email address")]
        //[StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }

        // [Required]
        //[StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }
    }

    public class Attachment
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
    }

    public class ECOS
    {
        /// <summary>
        /// Options:
        /// "0" : none;
        /// "1" : Vacant Possession
        /// "2" : Subject to existing tenancies
        public string LandOptionType { get; set; }
        /// <summary>
        public Improvement Improvements { get; set; }
        /// <summary>
        /// Options:
        /// "1": blinds, 
        /// "2": built-in wardrobes,
        /// "3": clothes line,
        /// "4": curtains,
        /// "5": dishwasher,
        /// "6": fixed floor coverings,
        /// "7": insect screens,
        /// "8": light fittings,
        /// "9": range hood,
        /// "10": solar panels,
        /// "11": stove,
        /// "12": pool equipment,
        /// "13": TV antenna
        /// If not in the options, values will be put into other text field
        /// </summary>
        public Inclusion Inclusions { get; set; }
        public string Exclusions { get; set; }
        public string IncludedGSTAmount { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public Tenancy Tenancy { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string AcceptDepositBond { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string AcceptProposedElectronicTransation { get; set; }
        public StrataHolderOrCommunityTitleRecords StrataHolderOrCommunityTitleRecords { get; set; }
        public string ContractCompletionDueDate { get; set; }
        public string DepositDueDate { get; set; }
        public string SettlementDueDate { get; set; }
        public string DepositPaidAmount { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string PlusGST { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string IsFarmingBusiness { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string IsGoingConcern { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string IsMarginSchemeUsed { get; set; }
        public string TransferredStatus { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string ParticularsOfLease { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string IsTermsContract { get; set; }
    }

    public class Improvement
    {
        public bool House { get; set; }
        public bool Garage { get; set; }
        public bool Carport { get; set; }
        public bool HomeUnit { get; set; }
        public bool Carspace { get; set; }
        public bool StorageSpace { get; set; }
        public bool None { get; set; }
        public bool Other { get; set; }
        public string OtherDescription { get; set; }
    }

    public class Inclusion
    {
        public bool Blinds { get; set; }
        public bool Curtains { get; set; }
        public bool InsectScreens { get; set; }
        public bool Stove { get; set; }
        public bool BuiltInWardrobe { get; set; }
        public bool Dishwasher { get; set; }
        public bool LightFittings { get; set; }
        public bool PoolEquipment { get; set; }
        public bool ClothesLine { get; set; }
        public bool FixedFloorCoverings { get; set; }
        public bool RangeHood { get; set; }
        public bool SolarPanel { get; set; }
        public bool TvAntenna { get; set; }
        public bool Other { get; set; }
        public string OtherDescription { get; set; }
    }

    public class Tenancy
    {
        public bool JointTenant { get; set; }
        public bool TenantsInCommon { get; set; }
        public bool InUnequalShares { get; set; }
    }

    public class StrataHolderOrCommunityTitleRecords
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
    }

    public class EDR
    {
        public string DocumentType { get; set; }
        public string NumberOfDuplicates { get; set; }
        public string NumberOfTransfers { get; set; }
        public string ConsiderationAmount { get; set; }
        public string ValueAmount { get; set; }
        public string GSTPayable { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string ExemptFromDuty { get; set; }
        public string DutiableAmount { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string FHPIncludeOtherPurchasers { get; set; }
        public string EligiblePurchasersInterest { get; set; }
        /// <summary>
        /// Options:
        /// "MB": Private Dwelling
        /// "MV": Vacant Land
        /// </summary>
        public string FHPRebateType { get; set; }
        /// <summary>
        /// Options:
        /// "NH": New Home
        /// "VL": Vacant Land
        /// </summary>
        public string NHGPropertyType { get; set; }
        public List<BookNo> BookNos { get; set; }
    }

    public class BookNo
    {
        public string Book { get; set; }
        public string No { get; set; }
    }

    public class LoanDetail
    {
        public string LenderName { get; set; }
        public string ApprovalDate { get; set; }
        /// <summary>
        /// Options: "true", "false", null
        /// </summary>
        public string SubjectToSpecialConditions { get; set; }

        public string LoanId { get; set; }
        public double? LoanAmount { get; set; }
        public double? InterestRate { get; set; }
        public int? Years { get; set; }
        public int? Months { get; set; }

        public double? MonthlyPayment { get; set; }

        public double? TotalMonthlyPayment { get; set; }

        public DateTime? DateFirstPaymentDue { get; set; }

        public DateTime? DateFinalPaymentDue { get; set; }

        public int? DayOfMonthPaymentDue { get; set; }

        public string Mortgagee { get; set; }
    }

    public class S32VendorStatement
    {
        public string RegisteredOrGeneralLawTitle { get; set; }
    }

    public class ENOS
    {
        public List<NotifiedEntity> NotifiedEntities { get; set; }
    }

    public class NotifiedEntity
    {
        public Individual Individual { get; set; }
        public Organisation Organisation { get; set; }
        public Address Address { get; set; }
        /// <summary>
        /// Options: "1": Owner
        /// "2": Owner's Agent
        /// </summary>
        public string WhoseNameIsShown { get; set; }
        /// <summary>
        /// Options:"true", "false", null
        /// </summary>
        public string SameAddressAsProperty { get; set; }
    }

    public class EntityDetail
    {
        private static string NormalizeEmailOrPhone(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Contains(" - ")
                ? value.Substring(value.IndexOf(" - ", StringComparison.Ordinal) + 3).Trim()
                : value;
        }

        private string _email;

        private string _phone;

        private string _fax;

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public string Email
        {
            get { return _email; }
            set { _email = NormalizeEmailOrPhone(value); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = NormalizeEmailOrPhone(value); }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = NormalizeEmailOrPhone(value); }
        }

        public virtual EntityDetailAddress Address { get; set; }

        public virtual EntityDetailOrganization Organisation { get; set; }

        public bool ContainsData()
        {
            return !string.IsNullOrWhiteSpace(Organisation?.ShortName);
        }

        public string GetFullNameOrOrganisationName()
        {
            return string.IsNullOrWhiteSpace(FirstName) ||
                   string.IsNullOrWhiteSpace(LastName)
                ? Organisation.ShortName
                : $"{FirstName} {LastName}";
        }

    }

    public class LawyerEntity
    {
        public string DisplayName { get; set; }
        public EntityDetailOrganization Organisation { get; set; }

        public EntityDetailAddress Address { get; set; }

        public List<EntityDetailIndividual> Individuals { get; set; }
    }

    public class EntityDetailOrganization : Organisation
    {
        public override bool Equals(object other)
        {
            var otherOrg = other as Organisation;
            if (otherOrg != null)
                return otherOrg.ShortName == ShortName;
            return false;
        }

        public override int GetHashCode()
        {
            return new { ShortName }.GetHashCode();
        }
    }

    public class EntityDetailAddress : Address
    {
        public override bool Equals(object other)
        {
            var otherAddress = other as Address;
            if (otherAddress != null)
                return otherAddress.StreetName == StreetName && otherAddress.StreetNumber == StreetNumber &&
                       otherAddress.PostCode == PostCode;
            return false;
        }

        public override int GetHashCode()
        {
            return new { StreetName, StreetNumber, PostCode }.GetHashCode();
        }
    }

    public class EntityDetailIndividual
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }
    }

    public class StockCertificate
    {
        public string IssueState { get; set; }
        public string IncorporationYear { get; set; }
        public int CompanyType { get; set; }
        public bool RepresentativeCertificates { get; set; }
        public bool PercentCertificates { get; set; }
        public int ShareQuantity { get; set; }
        public decimal ParValue { get; set; }
        public int OrderQuantity { get; set; }
        public int StartNumber { get; set; }
        public string CertificateSignedBy { get; set; }
        public List<string> ClauseCodes { get; set; }
        public bool LooseCertificates { get; set; }
        public bool FirmNameGoldLettered { get; set; }
        public int CertificateColor { get; set; }
        public int FreightOption { get; set; }
        public bool AppropriateLegends { get; set; }
        public bool ProfessionalByLaws { get; set; }
    }
}
