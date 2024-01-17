using System.Security.Cryptography;

namespace ShareContentPoC.Abstractions.Services
{
    public interface IShareService
	{
        void SharePlainText(string plainText);

        void SharePdf(string filePath);
    }
}

