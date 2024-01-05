using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LethalCompanySaveManager
{
	public class LCSecurity
	{
		public static readonly string Password = "lcslime14a5";

		public static string Decrypt(byte[] data)
		{
			byte[] IV = new byte[16];
			Array.Copy(data, IV, 16);
			byte[] dataToDecrypt = new byte[data.Length - 16];
			Array.Copy(data, 16, dataToDecrypt, 0, dataToDecrypt.Length);

			using (Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(Password, IV, 100, HashAlgorithmName.SHA1))
			using (Aes decAlg = Aes.Create())
			{
				decAlg.Mode = CipherMode.CBC;
				decAlg.Padding = PaddingMode.PKCS7;
				decAlg.Key = k2.GetBytes(16);
				decAlg.IV = IV;

				using (MemoryStream decryptionStreamBacking = new MemoryStream())
				using (CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write))
				{
					decrypt.Write(dataToDecrypt, 0, dataToDecrypt.Length);
					decrypt.FlushFinalBlock();

					return new UTF8Encoding(true).GetString(decryptionStreamBacking.ToArray());
				}
			}
		}

		public static byte[] Encrypt(string data)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.CBC;
				aesAlg.Padding = PaddingMode.PKCS7;
				aesAlg.KeySize = 128;

				// Generate a random IV
				aesAlg.GenerateIV();

				using (Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(Password, aesAlg.IV, 100, HashAlgorithmName.SHA1))
				{
					aesAlg.Key = keyDerivation.GetBytes(16); // 128-bit key

					using (MemoryStream encryptedStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
						{
							byte[] dataBytes = Encoding.UTF8.GetBytes(data);
							cryptoStream.Write(dataBytes, 0, dataBytes.Length);
						}

						byte[] iv = aesAlg.IV; // Get IV
						byte[] encryptedData = encryptedStream.ToArray(); // Get encrypted data

						// Combine IV and encrypted data
						byte[] ivAndEncryptedData = new byte[iv.Length + encryptedData.Length];
						Array.Copy(iv, 0, ivAndEncryptedData, 0, iv.Length);
						Array.Copy(encryptedData, 0, ivAndEncryptedData, iv.Length, encryptedData.Length);

						return ivAndEncryptedData;
					}
				}
			}
		}
	}
}
