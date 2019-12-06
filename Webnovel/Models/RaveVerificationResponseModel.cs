using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace Webnovel.Models
{
    public class RaveVerificationResponseModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

        
    }

            public class CardToken
        {
            public string embedtoken { get; set; }
            public string shortcode { get; set; }
            public string expiry { get; set; }
        }

public class Card
{
    public string expirymonth { get; set; }
    public string expiryyear { get; set; }
    public string cardBIN { get; set; }
    public string last4digits { get; set; }
    public string brand { get; set; }
    public List<CardToken> card_tokens { get; set; }
    public string life_time_token { get; set; }
}

public class Meta
{
    public int id { get; set; }
    public string metaname { get; set; }
    public string metavalue { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string deletedAt { get; set; }
    public string getpaidTransactionId { get; set; }
}

public class Data
{
    public string txid { get; set; }
    public string txref { get; set; }
    public string flwref { get; set; }
    public string devicefingerprint { get; set; }
    public string cycle { get; set; }
    public double amount { get; set; }
    public string currency { get; set; }
    public decimal chargedamount { get; set; }
    public string appfee { get; set; }
    public decimal merchantfee { get; set; }
    public decimal merchantbearsfee { get; set; }
    public string chargecode { get; set; }
    public string chargemessage { get; set; }
    public string authmodel { get; set; }
    public string ip { get; set; }
    public string narration { get; set; }
    public string status { get; set; }
    public string vbvcode { get; set; }
    public string vbvmessage { get; set; }
    public string authurl { get; set; }
    public string acctcode { get; set; }
    public string acctmessage { get; set; }
    public string paymenttype { get; set; }
    public string paymentid { get; set; }
    public string fraudstatus { get; set; }
    public string chargetype { get; set; }
    public string createdday { get; set; }
    public string createddayname { get; set; }
    public string createdweek { get; set; }
    public string createdmonth { get; set; }
    public string createdmonthname { get; set; }
    public string createdquarter { get; set; }
    public string createdyear { get; set; }
    public bool createdyearisleap { get; set; }
    public string createddayispublicholiday { get; set; }
    public string createdhour { get; set; }
    public string createdminute { get; set; }
    public string createdpmam { get; set; }
    public DateTime created { get; set; }
    public string customerid { get; set; }
    public string custphone { get; set; }
    public string custnetworkprovider { get; set; }
    public string custname { get; set; }
    public string custemail { get; set; }
    public string custemailprovider { get; set; }
    public DateTime custcreated { get; set; }
    public string accountid { get; set; }
    public string acctbusinessname { get; set; }
    public string acctcontactperson { get; set; }
    public string acctcountry { get; set; }
    public string acctbearsfeeattransactiontime { get; set; }
    public string acctparent { get; set; }
    public string acctvpcmerchant { get; set; }
    public string acctalias { get; set; }
    public string acctisliveapproved { get; set; }
    public string orderref { get; set; }
    public string paymentplan { get; set; }
    public string paymentpage { get; set; }
    public string raveref { get; set; }
    public string amountsettledforthistransaction { get; set; }
    public Card card { get; set; }
    public List<Meta> meta { get; set; }
}

    public class RaveVerificationData
    {
        public string txref { get; set; }
        public string SECKEY { get; set; }
    }

}
