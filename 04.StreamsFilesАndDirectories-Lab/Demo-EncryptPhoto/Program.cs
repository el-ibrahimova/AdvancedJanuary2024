namespace Demo_EncryptPhoto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncryptFile("../../../photo.jpg");  // криптирай файла photo.jpg

            // при първото изпълнение на програмата, файла се криптира
            // при повторно изпълнение = файла се декриптира и снимката може да се прочете
        }

       static void EncryptFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                byte[] data = new byte[stream.Length]; // създаваме масив от байтове, който съдържа всички байтове на файла

                stream.Read(data, 0, data.Length); // прочитаме всичките елементи от масива 

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i] ^ 183); // променяме всеки един байт от файла с оператор XOR(^) с произволно число = 183. Използваме него, защото при декриптиране, използвайки пак същия оператор, със същото число, връщаме оригиналните стойности от байтовете на файла
                }

                stream.Seek(0, SeekOrigin.Begin);
                stream.Write(data, 0, data.Length);  // изпиши елементите от масива

                Console.WriteLine(data.Length); // на конзолата изписваме колко байта съдържа файла
                Console.WriteLine(string.Join(" ", data));  // на конзолата се изписва вече променената стойност на файла => снимката вече не може да се прочете
            }
        }
    }
}
