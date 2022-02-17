public class PersonModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
    public object DeepCopy()
    {
        List<AddressModel> addresses = new List<AddressModel>();
        foreach(var address in Addresses)
        {
            addresses.Add((AddressModel)address.DeepCopy());
        }
        var obj = new PersonModel { FirstName = this.FirstName, LastName = this.LastName, DateOfBirth = this.DateOfBirth, Addresses = addresses};
        return obj;
    }
}
