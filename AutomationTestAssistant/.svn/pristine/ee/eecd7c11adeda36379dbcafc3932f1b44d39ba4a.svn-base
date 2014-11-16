using System.IO;

public static class Encryptor
{
	const int ENCRYPT_SIZE = 5;

	public static void EncryptData(Stream inputStream, Stream outputStream)
	{
		byte[] buf = new byte[ENCRYPT_SIZE];
		while (true)
		{
			int bytesRead = ReadBlock(inputStream, buf);
			if (bytesRead == 0)
			{
				break;
			}
			byte[] reversedBuffer = ShiftByteArrayRight(buf, bytesRead);
			outputStream.Write(reversedBuffer, 0, bytesRead);
		}
	}

	private static int ReadBlock(Stream stream, byte[] buf)
	{
		int bytesLeft = buf.Length;
		int offset = 0;
		while (bytesLeft > 0)
		{
			int bytesRead = stream.Read(buf, offset, bytesLeft);
			if (bytesRead == 0)
			{
				// The stream has ended => stop reading
				break;
			}
			offset += bytesRead;
			bytesLeft -= bytesRead;
		}
		return buf.Length - bytesLeft;
	}

	public static byte[] ShiftByteArrayRight(byte[] inputByteArray, int size)
	{
		byte[] newByteArray = new byte[size];
		newByteArray[0] = inputByteArray[size - 1];
		for (int index = 1; index < size; index++)
		{
			newByteArray[index] = inputByteArray[index - 1];
		}
		return newByteArray;
	}
	
	public static void DecryptData(Stream inputStream, Stream outputStream)
	{
		byte[] buf = new byte[ENCRYPT_SIZE];
		while (true)
		{
			int bytesRead = ReadBlock(inputStream, buf);
			if (bytesRead == 0)
			{
				break;
			}
			byte[] reversedBuffer = ShiftByteArrayLeft(buf, bytesRead);
			outputStream.Write(reversedBuffer, 0, bytesRead);
		}
	}

	public static byte[] ShiftByteArrayLeft(byte[] inputByteArray, int size)
	{
		byte[] newByteArray = new byte[size];
        newByteArray[size - 1] = inputByteArray[0];
		for (int index = 1; index < size; index++)
		{
			newByteArray[index - 1] = inputByteArray[index];
		}
		return newByteArray;
	}
}


