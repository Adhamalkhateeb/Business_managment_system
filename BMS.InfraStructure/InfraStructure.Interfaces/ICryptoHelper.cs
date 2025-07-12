
namespace BMS.InfraStructure.InfraStructure.interfaces
{
    public interface ICryptoHelper
    {
        string ComputeHash(string input);
        string Encrypt(string input);
        string Decrypt(string encryptedInput);
    }
}
