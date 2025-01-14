﻿namespace DotEnv.Core.Tests.Parser;

public partial class EnvParserTests
{
    [TestMethod]
    public void Parse_WhenDisabledTrimStartValues_ShouldNotIgnoreLeadingWhitepaces()
    {
        string env = "TRIM_START_VALUES=   1";

        new EnvParser()
            .DisableTrimStartValues()
            .Parse(env);

        Assert.AreEqual(expected: "   1", actual: GetEnvironmentVariable("TRIM_START_VALUES"));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimEndValues_ShouldNotIgnoreTrailingWhitepaces()
    {
        string env = "TRIM_END_VALUES=1   ";

        new EnvParser()
            .DisableTrimEndValues()
            .Parse(env);

        Assert.AreEqual(expected: "1   ", actual: GetEnvironmentVariable("TRIM_END_VALUES"));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimValues_ShouldNotIgnoreWhitepaces()
    {
        string env = "TRIM_VALUES=   1   ";

        new EnvParser()
            .DisableTrimValues()
            .Parse(env);

        Assert.AreEqual(expected: "   1   ", actual: GetEnvironmentVariable("TRIM_VALUES"));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimStartKeys_ShouldNotIgnoreLeadingWhitepaces()
    {
        string env = "   TRIM_START_KEYS=1";

        new EnvParser()
            .DisableTrimStartKeys()
            .Parse(env);

        Assert.AreEqual(expected: "1", actual: GetEnvironmentVariable("   TRIM_START_KEYS"));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimEndKeys_ShouldNotIgnoreTrailingWhitepaces()
    {
        string env = "TRIM_END_KEYS   =1";

        new EnvParser()
            .DisableTrimEndKeys()
            .Parse(env);

        Assert.AreEqual(expected: "1", actual: GetEnvironmentVariable("TRIM_END_KEYS   "));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimKeys_ShouldNotIgnoreWhitepaces()
    {
        string env = "   TRIM_KEYS   =1";

        new EnvParser()
            .DisableTrimKeys()
            .Parse(env);

        Assert.AreEqual(expected: "1", actual: GetEnvironmentVariable("   TRIM_KEYS   "));
    }

    [TestMethod]
    public void Parse_WhenDisabledTrimStartComments_ShouldNotIgnoreLeadingWhitepaces()
    {
        string env = "   #comment1";
        var parser = new EnvParser().DisableTrimStartComments();

        void action() => parser.Parse(env);

        var ex = Assert.ThrowsException<ParserException>(action);
        StringAssert.Contains(ex.Message, string.Format(LineHasNoKeyValuePairMessage, "  "));
    }

    [TestMethod]
    public void Parse_WhenAllowedOverwriteExistingVars_ShouldBeAbleToOverwriteValue()
    {
        string env = @"
                ALLOW_OVERWRITE_1 = VAL1
                ALLOW_OVERWRITE_2 = VAL2
            ";
        SetEnvironmentVariable("ALLOW_OVERWRITE_1", "1");
        SetEnvironmentVariable("ALLOW_OVERWRITE_2", "2");

        new EnvParser()
            .AllowOverwriteExistingVars()
            .Parse(env);

        Assert.AreEqual(expected: "VAL1", actual: GetEnvironmentVariable("ALLOW_OVERWRITE_1"));
        Assert.AreEqual(expected: "VAL2", actual: GetEnvironmentVariable("ALLOW_OVERWRITE_2"));
    }

    [TestMethod]
    public void Parse_WhenSetsCommentChar_ShouldIgnoreComment()
    {
        string env = @"
                ;KEY1 = VAL1
                ;KEY2 = VAL2
            ";

        new EnvParser()
            .SetCommentChar(';')
            .Parse(env);

        Assert.IsNull(GetEnvironmentVariable(";KEY1"));
        Assert.IsNull(GetEnvironmentVariable(";KEY2"));
    }

    [TestMethod]
    public void Parse_WhenSetsDelimiterKeyValuePair_ShouldReadKeyValuePair()
    {
        string env = @"
                DELIMITER_KEYVALUE_1 : VAL1
                DELIMITER_KEYVALUE_2:VAL2
            ";

        new EnvParser()
            .SetDelimiterKeyValuePair(':')
            .Parse(env);

        Assert.AreEqual(expected: "VAL1", actual: GetEnvironmentVariable("DELIMITER_KEYVALUE_1"));
        Assert.AreEqual(expected: "VAL2", actual: GetEnvironmentVariable("DELIMITER_KEYVALUE_2"));
    }

    [TestMethod]
    public void Parse_WhenIgnoresParserException_ShouldNotThrowParserException()
    {
        string env = @"
                asdasdasdasd
                IGNORE_EXCEPTION_1=VAL1 ${IGNORE_EXCEPTION_2} ...
                KEY1:VAL1
                This isn't a comment.
                IGNORE_EXCEPTION_2=VAL2 ${IGNORE_EXCEPTION_2} ...
                =VAL1
                IGNORE_EXCEPTION_3= ASDASD ${} ${   }
                IGNORE_EXCEPTION_4= ASDASD ${   } ASDASD ${}
                IGNORE_EXCEPTION_5 = server=${MYSQL_HOST};user=root${ };
                IGNORE_EXCEPTION_6 = server= ${MYSQL_HOST} ; user=root;
            ";

        new EnvParser()
            .IgnoreParserException()
            .Parse(env);

        Assert.AreEqual(expected: "VAL1  ...", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_1"));
        Assert.AreEqual(expected: "VAL2  ...", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_2"));
        Assert.AreEqual(expected: "ASDASD", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_3"));
        Assert.AreEqual(expected: "ASDASD  ASDASD", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_4"));
        Assert.AreEqual(expected: "server=;user=root;", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_5"));
        Assert.AreEqual(expected: "server=  ; user=root;", actual: GetEnvironmentVariable("IGNORE_EXCEPTION_6"));
    }

    [TestMethod]
    public void Parse_WhenAllowedConcatDuplicateKeysAtEnd_ShouldConcatenateDuplicateKeys()
    {
        string env = @"
                CONCAT_END2 = 1
                CONCAT_END1 = Hello
                CONCAT_END1 = World
                CONCAT_END1 = !
                CONCAT_END1 = !
            ";
        SetEnvironmentVariable("CONCAT_END2", "2");

        new EnvParser()
            .AllowConcatDuplicateKeys()
            .Parse(env);

        Assert.AreEqual(expected: "HelloWorld!!", actual: GetEnvironmentVariable("CONCAT_END1"));
        Assert.AreEqual(expected: "21", actual: GetEnvironmentVariable("CONCAT_END2"));
    }


    [TestMethod]
    public void Parse_WhenAllowedConcatDuplicateKeysAtStart_ShouldConcatenateDuplicateKeys()
    {
        string env = @"
                CONCAT_START2 = 1
                CONCAT_START1 = !
                CONCAT_START1 = !
                CONCAT_START1 = World
                CONCAT_START1 = Hello
            ";
        SetEnvironmentVariable("CONCAT_START2", "2");

        new EnvParser()
            .AllowConcatDuplicateKeys(ConcatKeysOptions.Start)
            .Parse(env);

        Assert.AreEqual(expected: "HelloWorld!!", actual: GetEnvironmentVariable("CONCAT_START1"));
        Assert.AreEqual(expected: "12", actual: GetEnvironmentVariable("CONCAT_START2"));
    }

    [TestMethod]
    [DataRow(-1)]
    [DataRow(3)]
    [DataRow(4)]
    public void AllowConcatDuplicateKeys_WhenOptionIsInvalid_ShouldThrowArgumentException(int option)
    {
        var parser = new EnvParser();

        void action() => parser.AllowConcatDuplicateKeys((ConcatKeysOptions)option);

        Assert.ThrowsException<ArgumentException>(action);
    }

    [TestMethod]
    public void Parse_WhenEnvironmentCannotBeModified_ShouldStoreTheKeysInDictionary()
    {
        string env = @"
                AVOID_MOD_1 = Hello
                AVOID_MOD_1 = World
                AVOID_MOD_2 = ${AVOID_MOD_1}
            ";

        var keyValuePairs = new EnvParser()
                                .AvoidModifyEnvironment()
                                .AllowConcatDuplicateKeys()
                                .Parse(env);

        Assert.AreEqual(expected: "HelloWorld", actual: keyValuePairs["AVOID_MOD_1"]);
        Assert.AreEqual(expected: "HelloWorld", actual: keyValuePairs["AVOID_MOD_2"]);
        Assert.IsNull(GetEnvironmentVariable("AVOID_MOD_1"));
        Assert.IsNull(GetEnvironmentVariable("AVOID_MOD_2"));
    }

    [TestMethod]
    public void Parse_WhenKeyDoesNotExistInTheDictionary_ShouldThrowParserException()
    {
        var parser = new EnvParser().AvoidModifyEnvironment();
        string env = @"
                AVOID_MOD_1 = 1
                AVOID_MOD_1 = ${VARIABLE_NOT_FOUND}
            ";

        void action() => parser.Parse(env);

        var ex = Assert.ThrowsException<ParserException>(action);
        StringAssert.Contains(ex.Message, string.Format(VariableNotSetMessage, "VARIABLE_NOT_FOUND"));
    }

    [TestMethod]
    public void Parse_WhenSetsEnvironmentVariablesProvider_ShouldStoreTheKeysInCustomProvider()
    {
        var customProvider = new CustomEnvironmentVariablesProvider();
        new EnvParser()
            .AllowOverwriteExistingVars()
            .SetEnvironmentVariablesProvider(provider: customProvider)
            .Parse("KEY1=1\nKEY2=2\nKEY1=2");

        Assert.AreEqual(expected: "2", actual: customProvider["KEY1"]);
        Assert.AreEqual(expected: "2", actual: customProvider["KEY2"]);
        Assert.IsNull(GetEnvironmentVariable("KEY1"));
        Assert.IsNull(GetEnvironmentVariable("KEY2"));
    }
}
