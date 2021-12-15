using NUnit.Framework;
using Hybrid;
using System.Security.Cryptography;
using Hybrid.Models;
using Hybrid.Keys;
using Hybrid.Providers.Asymmetric;
using Hybrid.Providers.Symmetric;

namespace HybridEncryptTest
{
    public class Tests
    {
        [TestCase("1 test string To EnCrypt!8")]
        [TestCase("")]
        [TestCase("avisjdkcampuwewergwreao,pldcsop0relpc[.d;alp,afu8rigme84re0kcok")]
        public void HybridDecrypt_ValidData_DecryptedText(string text)
        {
            // arrange
            HybridProvider provider1 = new HybridProvider();
            SymmetricTextModel encrypted = provider1.HybridEncryption(text);

            HybridProvider provider2 = new HybridProvider();

            // act
            string decrypted = provider2.HybridDecryption(encrypted);

            // assert
            Assert.AreEqual(text, decrypted);
        }

        [TestCase("PotftYKZLt/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=")]
        [TestCase("uC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=")]
        [TestCase("uuuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=")]
        [TestCase("iuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=")]
        public void HybridDecrypt_WrongKey_null(string key)
        {
            // arrange
            HybridProvider provider = new HybridProvider();
            SymmetricTextModel encrypted = new SymmetricTextModel
            {
                Text = "teeQN1+yO1+7XmUvhHeXls6VbKlVpAxu0ZmSH5fMcGw=",
                Key = "uuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=",
                IV = "qqNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE="
            };
            encrypted.Key = key;

            // act
            string decrypted = provider.HybridDecryption(encrypted);
            // assert
            Assert.IsNull(decrypted);
        }

        [TestCase("qvfsfdvskpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE=")]
        [TestCase("qNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE=")]
        [TestCase("qqqNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE=")]
        [TestCase("iqNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE=")]
        public void HybridDecrypt_WrongIV_null(string iv)
        {
            // arrange
            HybridProvider provider = new HybridProvider();
            SymmetricTextModel encrypted = new SymmetricTextModel
            {
                Text = "teeQN1+yO1+7XmUvhHeXls6VbKlVpAxu0ZmSH5fMcGw=",
                Key = "uuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=",
                IV = "qqNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE="
            };
            encrypted.IV = iv;

            // act
            string decrypted = provider.HybridDecryption(encrypted);
            // assert
            Assert.IsNull(decrypted);
        }
        
        [Test]
        public void AsymmetricDecriptString_WithoutPrivateKey_CryptographicException()
        {
            // arrange
            string test = "uuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=";
            string key = AsymmetricKeys.GetInstance().GetPublicKey();
            AsymmetricProvider asymmetricProvider = new AsymmetricProvider();
            AsymmetricTextModel model = new AsymmetricTextModel(test, key);

            // act
            // assert
            Assert.Throws<CryptographicException>(() => asymmetricProvider.Decrypt(model));
        }

        [Test]
        public void SymmetricDecript_InvalidText_null()
        {
            // arrange
            SymmetricTextModel encrypted = new SymmetricTextModel
            {
                Text = "teeeQN1+yO1+7XmUvhHeXls6VbKlVpAxu0ZmSH5fMcGw=",
                Key = "uuC8VE+sVK9y7Xo6orJhynKgySBhx1Sp9xd0GeAHsiEy6O9Efyy/xgfNpxhsK3ILLb198wdBW3/yUH0hwC2RjrsSNoA9F2v+QcyBRUWTR/cX/jKXtBevPYqQ5ErPotftYKZLO0tyufdcaNV9rx6TY4J1ifTvHdQJAHjuIB1HmBqe249ZW+lkkWykqRTl6hJVcZQ1M7Vky1wPAfE5SrR4AScIb6uOjZA2Fk1H8jIDxKpgPALeVO1mxFMrbKvigq7jh1wa4NFBHrJFO/FDiEddDzOijvfEzD3CTY3oiOAasrRx9pjAMyGwDYbHOH/XjQB6zhpKlptGGCKr0ImMZK16aDb0rP3Se5EKRRJJY0oi3PIpAD/kA5rj7B1o9UkAhmQoZXtlVBSGM9zX2bhqEm33f162pvQ9SbC0pN0TYrHnS+pDmbhx45gTOY5viX//+0zAR3twg2iuRPEIzo738rzywNlVekMOXEpDINEbf9f14KSMRvfZRoqj07NhxHp80ztVULoGSeclVleuzIUSZGHgTod+BfpggrxNYPe5oW6HgP67IV+V/qnr+eKBY0grOSHvT5wFSVC9gYsvBNZHMSISdWh/zuiNDwaMaTHRft/ULN1Ib8a5hjF6rJJonpQuD+2znvqQwfALuhrALcKtQemD3wxM6Jzl4UUW46iNk4ywn6g=",
                IV = "qqNToNVcV7aAkpJFo4CUESZe791P3K3z6ZWwIbZOjBUXo6DdwZPUT7hZ0Pj1dKbEWV29+aevF5ZgLZBnVHRtW5kfN2u2+fiCzJYjYAyl/rtR9TCP1E+pQ4U6JbkEtK7WpG9VI790WkcxInw2o/qYElBuOefgChZ6L5v5lga9ZS34clQP60bpqPDusM/EFtHVsQv9w9ScmzLMdpgOqoLH8TAio15n1B+Lm/ps3nJUBdldj1PhmeDo448L2OypfJm/TuGZ/tlmPEg/jZVq5RIJv0PfgsciNfQD/pEE7vpCp/dTq3aW4ZMkuL24GigQNP9yVr1VGOxPAOPrR1UOdFZQnuIXRPyD11XAR0ecRzH8f5rXhcLW3ZKx6ab5YUM0iMqXG1/PVcXQpU5/8w6aNx75Iw0t8WbAkhtWgQlloqAlyziw/pS1ZZfnwM57EMxW1BvIThjB3QBfghdjUPV2kCLA9968mZK+V2wiJH5G3cYgah4TnkY9R/trv2qh4bbiyCI374LruD0TnPJL72rqiBNbA2uuZyHYqatS4lAWYB6lvgmsmbS51tkVbX/sqQgOBtDRMUJZBQlLYDJb0O45oQT+qLgs6fZ6wPP3I8GhHAmO/5DAm2TcCQyy9Dx1BcRWX2Aeem8itSwVHHwux5bWnKq3+j1Ewb+NZCNpKpNEug0JabE="
            };
            SymmetricProvider symmetricProvider = new SymmetricProvider();
            SymmetricTextModel model = new SymmetricTextModel(encrypted.Text, encrypted.Key, encrypted.IV);

            // act
            string decrypted = symmetricProvider.Decrypt(model);

            // assert
            Assert.IsNull(decrypted);
        }
    }
}