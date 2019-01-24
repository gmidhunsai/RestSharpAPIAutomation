using System;
using System.Collections.Generic;

namespace Models
{
    public class Attributes
    {
    }

    public class TitleId
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class RecommendedTitles
    {
        public string OfferCode { get; set; }
        public List<TitleId> TitleIds { get; set; }
    }

    public class AcceptedOffer
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public DateTime? optedInDate { get; set; }
        public string timeToComplete { get; set; }
        public string progressTrackerCode { get; set; }
        public int currentValue { get; set; }
        public int maxValue { get; set; }
        public string endValueText { get; set; }
        public int remainderValue { get; set; }
        public DateTime? completeDate { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<string> Details { get; set; }
    }

    public class LoginResponse
    {
        public string HostName { get; set; }
        public string CustomerProfileNumber { get; set; }
        public string FirstName { get; set; }
        public string LoginEmail { get; set; }
        public DateTime? BirthDate { get; set; }
        public int LoyaltyPointBalance { get; set; }
        public object LoyaltyTier { get; set; }
        public int LoyaltyTierCounter { get; set; }
        public int PointsExpiring { get; set; }
        public Attributes Attributes { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsEnrolledInLoyalty { get; set; }
        public string EarlyIdOptInStatus { get; set; }
        public string TextClubOptInStatus { get; set; }
        public RecommendedTitles RecommendedTitles { get; set; }
        public List<object> PromoCodes { get; set; }
        public bool? IsEmailVerified { get; set; }
        public List<AcceptedOffer> AcceptedOffers { get; set; }
        public bool? IsSuccess { get; set; }
        public List<Error> Errors { get; set; }
    }
}