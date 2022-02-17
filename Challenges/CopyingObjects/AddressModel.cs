public class AddressModel
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public object DeepCopy()
    {
        return new AddressModel{ StreetAddress = this.StreetAddress, City = this.City, State = this.State, ZipCode = this.ZipCode};
    }
}

