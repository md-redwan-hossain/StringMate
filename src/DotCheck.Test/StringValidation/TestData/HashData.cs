namespace DotCheck.Test.StringValidation.TestData;

public static class HashData
{
    public static readonly string[] ValidMd5 =
    {
        "d94f3f016ae679c3008de268209132f2",
        "751adbc511ccbe8edf23d486fa4581cd",
        "88dae00e614d8f24cfd5a8b3f8002e93",
        "0bf1c35032a71a14c2f719e5a14c1e96"
    };

    public static readonly string[] InvalidMd5 =
    {
        "KYT0bf1c35032a71a14c2f719e5a14c1",
        "q94375dj93458w34",
        "39485729348",
        "%&FHKJFvk"
    };


    public static readonly string[] ValidSha256 =
    {
        "2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824",
        "1d996e033d612d9af2b44b70061ee0e868bfd14c2dd90b129e1edeb7953e7985",
        "80f70bfeaed5886e33536bcfa8c05c60afef5a0e48f699a7912d5e399cdcc441",
        "579282cfb65ca1f109b78536effaf621b853c9f7079664a3fbe2b519f435898c",
        "2CF24dba5FB0a30e26E83b2AC5b9E29E1b161e5C1fa7425E73043362938b9824",
        "80F70bFEAed5886e33536bcfa8c05c60aFEF5a0e48f699a7912d5e399cdCC441"
    };

    public static readonly string[] InvalidSha256 =
    {
        "KYT0bf1c35032a71a14c2f719e5a14c1",
        "KYT0bf1c35032a71a14c2f719e5a14c1dsjkjkjkjkkjk",
        "q94375dj93458w34",
        "39485729348",
        "%&FHKJFvk"
    };


    public static readonly string[] ValidSha512 =
    {
        "9b71d224bd62f3785d96d46ad3ea3d73319bfbc2890caadae2dff72519673ca72323c3d99ba5c11d7c7acc6e14b8c5da0c4663475c2e5c3adef46f73bcdec043",
        "83c586381bf5ba94c8d9ba8b6b92beb0997d76c257708742a6c26d1b7cbb9269af92d527419d5b8475f2bb6686d2f92a6649b7f174c1d8306eb335e585ab5049",
        "45bc5fa8cb45ee408c04b6269e9f1e1c17090c5ce26ffeeda2af097735b29953ce547e40ff3ad0d120e5361cc5f9cee35ea91ecd4077f3f589b4d439168f91b9",
        "432ac3d29e4f18c7f604f7c3c96369a6c5c61fc09bf77880548239baffd61636d42ed374f41c261e424d20d98e320e812a6d52865be059745fdb2cb20acff0ab",
        "9B71D224bd62f3785D96d46ad3ea3d73319bFBC2890CAAdae2dff72519673CA72323C3d99ba5c11d7c7ACC6e14b8c5DA0c4663475c2E5c3adef46f73bcDEC043",
        "432AC3d29E4f18c7F604f7c3c96369A6C5c61fC09Bf77880548239baffd61636d42ed374f41c261e424d20d98e320e812a6d52865be059745fdb2cb20acff0ab"
    };

    public static readonly string[] InvalidSha512 =
    {
        "KYT0bf1c35032a71a14c2f719e5a14c1",
        "KYT0bf1c35032a71a14c2f719e5a14c1dsjkjkjkjkkjk",
        "q94375dj93458w34",
        "39485729348",
        "%&FHKJFvk"
    };
}