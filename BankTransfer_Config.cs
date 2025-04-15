using System;
using System.IO;
using System.Text.Json;
public class BankTransfer_Config
{
    private const string FileName = "bank_transfer_config.json";
    public string lang { get; set; }
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
    public List<string> methods { get; set; }
    public string en { get; set; }
    public string id { get; set; }

    public BankTransfer_Config()
    {
        SetDefault();
    }
    public static BankTransfer_Config Load()
    {
        if(File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<BankTransfer_Config>(json);
        }
        else
        {
            BankTransfer_Config config = new BankTransfer_Config();
            config.SaveConfig();
            return config;
        }
    }
    public void SetDefault()
    {
        lang = "en";
        threshold = 25000000;
        low_fee = 7500;
        high_fee = 15000;
        methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        en = "yes";
        id = "ya";
    }
    public void SaveConfig()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(FileName, json);
    }
    public void ReadConfigFile()
    {
        if (File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);
            BankTransfer_Config config = JsonSerializer.Deserialize<BankTransfer_Config>(json);
            lang = config.lang;
            threshold = config.threshold;
            low_fee = config.low_fee;
            high_fee = config.high_fee;
            methods = config.methods;
            en = config.en;
            id = config.id;
        }
        else
        {
            SetDefault();
        }
    }
    public void WriteNewConfigFile()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(FileName, json);
    }
}