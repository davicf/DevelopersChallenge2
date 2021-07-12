using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Finances.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Domain.Accounts;
using Xayah.Finances.Domain.Common.Exception;
using Xayah.Finances.Tests.Unit.Shared.Mocks.Data.Repository.Accounts;
using Xayah.Finances.Tests.Unit.Shared.Mocks.Data.Specifications.Accounts.GetAccountByNumber;
using Xunit;

namespace Xayah.Finances.Tests.Unit.Business.UseCases.AddAccounts
{
    [Trait(nameof(AddAccountsUseCase), "")]
    public class AddAccountsUseCaseTestUnit
    {
        [Fact(DisplayName = "Must add accounts")]
        public async Task MustAddAccounts()
        {
            // Arrange
            var file = GetFormFile();

            var files = new List<IFormFile> { file };

            var instance = new AddAccountsUseCase(new MockAccountRepository().Get(null).Instance,
                                                  new MockGetAccountByNumberSpecification().Instance);

            // Act
            var response = await instance.AddAccountsAsync(files);

            // Assert		  
            response.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "Must throw exception account already exists")]
        public async Task MustThrowExceptionAddAccounts()
        {
            // Arrange
            var file = GetFormFile();

            var files = new List<IFormFile> { file };

            var instance = new AddAccountsUseCase(new MockAccountRepository().Get(A.Dummy<Account>()).Instance,
                                                  new MockGetAccountByNumberSpecification().Instance);

            // Act
            Func<Task> response = async () => await instance.AddAccountsAsync(files);

            // Assert		  
            response.Should().NotBeNull();
            response.Should().Throw<BusinessRuleException>();
        }

        #region GetFormFile
        private IFormFile GetFormFile()
        {
            var memorySteam = new MemoryStream();
            var writer = new StreamWriter(memorySteam);
            writer.Write(GetTemplate());
            writer.Flush();
            memorySteam.Position = 0;

            IFormFile file = new FormFile(memorySteam, 0, memorySteam.Length, "test", "test.ofx");

            return file;
        }
        #endregion

        #region Template
        private string GetTemplate()
        {
            var template = "OFXHEADER: 100\r\nDATA: OFXSGML\r\nVERSION: 102\r\nSECURITY: NONE\r\nENCODING: USASCII\r\nCHARSET: 1252\r\nCOMPRESSION: NONE" +
                           "\r\nOLDFILEUID: NONE\r\nNEWFILEUID: NONE\r\n\r\n<OFX>\r\n<SIGNONMSGSRSV1>\r\n<SONRS>\r\n<STATUS>\r\n<CODE>0" +
                           "\r\n<SEVERITY>INFO\r\n</STATUS>\r\n<DTSERVER>20140318100000[-03:EST]\r\n<LANGUAGE>POR\r\n</SONRS>\r\n</SIGNONMSGSRSV1>" +
                           "\r\n<BANKMSGSRSV1>\r\n<STMTTRNRS>\r\n<TRNUID>1001\r\n<STATUS>\r\n<CODE>0\r\n<SEVERITY>INFO\r\n</STATUS>\r\n<STMTRS>" +
                           "\r\n<CURDEF>BRL\r\n<BANKACCTFROM>\r\n<BANKID>0341\r\n<ACCTID>7037300576\r\n<CCTTYPE>CHECKING\r\n</BANKACCTFROM>\r\n<BANKTRANLIST>" +
                           "\r\n<DTSTART>20140201100000[-03:EST]\r\n<DTEND>2014020100000[-03:EST]\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140203100000[-03:EST]" +
                           "\r\n<TRNAMT>-140.00\r\n<MEMO>CXE     001958 SAQUE    \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140204100000[-03:EST]" +
                           "\r\n<TRNAMT>-102.19\r\n<MEMO>RSHOP-SUPERMERCAD - 03 / 02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140204100000[-03:EST]" +
                           "\r\n<TRNAMT>-4000.00\r\n<MEMO>TBI 0304.40719 - 0     C / C\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140204100000[-03:EST]" +
                           "\r\n<TRNAMT>-39.00\r\n<MEMO>TAR PACOTE MENS    01 / 14\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140204100000[-03:EST]" +
                           "\r\n<TRNAMT>-12.00\r\n<MEMO>TAR DOC INTERNET        \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140204100000[-03:EST]" +
                           "\r\n<TRNAMT>435.00\r\n<MEMO>DOC 399.1934NIBO SOF CUR\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140205100000[-03:EST]" +
                           "\r\n<TRNAMT>-2000.00\r\n<MEMO>INT APLICACAO SPECIAL RF\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140205100000[-03:EST]" +
                           "\r\n<TRNAMT>-979.16\r\n<MEMO>SISDEB  AUXIL PRED RIO  \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140210100000[-03:EST]" +
                           "\r\n<TRNAMT>-19.00\r\n<MEMO>RSHOP-MEGA MATE - 07 / 02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140210100000[-03:EST]" +
                           "\r\n<TRNAMT>-314.45\r\n<MEMO>RSHOP-SUPERMERCAD - 09 / 02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140210100000[-03:EST]" +
                           "\r\n<TRNAMT>-200.00\r\n<MEMO>SAQUE 24H 12725743      \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140210100000[-03:EST]\r\n<TRNAMT>-203.15" +
                           "\r\n<MEMO>SISDEB  SEM PARAR       \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140210100000[-03:EST]\r\n<TRNAMT>16766.28" +
                           "\r\n<MEMO>TED 399.1934NIBO SOF CUR\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140211100000[-03:EST]\r\n<TRNAMT>-43.00" +
                           "\r\n<MEMO>RSHOP-BIBI SUCOS -10/02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140211100000[-03:EST]\r\n<TRNAMT>-79.73" +
                           "\r\n<MEMO>RSHOP-MDL        -10/02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140211100000[-03:EST]\r\n<TRNAMT>-2000.00" +
                           "\r\n<MEMO>TBI 0304.40719-0     C/C\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140211100000[-03:EST]\r\n<TRNAMT>-10000.00" +
                           "\r\n<MEMO>INT APLICACAO SPECIAL RF\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140212100000[-03:EST]\r\n<TRNAMT>-95.00" +
                           "\r\n<MEMO>RSHOP-LEITERIA MI-11/02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140212100000[-03:EST]\r\n<TRNAMT>-7296.12" +
                           "\r\n<MEMO>SISDEB  CARTAO AMEX     \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140213100000[-03:EST]\r\n<TRNAMT>-62.90" +
                           "\r\n<MEMO>RSHOP-TOK E STOK -12/02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140217100000[-03:EST]\r\n<TRNAMT>-224.90" +
                           "\r\n<MEMO>RSHOP-SUPERMERCAD-15/02 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140217100000[-03:EST]\r\n<TRNAMT>-720.70" +
                           "\r\n<MEMO>SISDEB  SUL AMERIC SEG  \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140217100000[-03:EST]\r\n<TRNAMT>-529.71" +
                           "\r\n<MEMO>CREDIARIO AUT PERS12/12 \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140217100000[-03:EST]\r\n<TRNAMT>1556.91" +
                           "\r\n<MEMO>INT RESGATE   SPECIAL RF\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140218100000[-03:EST]\r\n<TRNAMT>-676.26" +
                           "\r\n<MEMO>DOC INT 516011 microlux \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140218100000[-03:EST]\r\n<TRNAMT>501.12" +
                           "\r\n<MEMO>INT RESGATE   SPECIAL RF\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140218100000[-03:EST]\r\n<TRNAMT>501.12" +
                           "\r\n<MEMO>INT RESGATE   SPECIAL RF\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140219100000[-03:EST]\r\n<TRNAMT>-2669.46" +
                           "\r\n<MEMO>INT PAG TIT BANCO 745   \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140219100000[-03:EST]\r\n<TRNAMT>-500.00" +
                           "\r\n<MEMO>TBI 8123.05928-2ana     \r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>DEBIT\r\n<DTPOSTED>20140219100000[-03:EST]\r\n<TRNAMT>-345.00" +
                           "\r\n<MEMO>CH COMPENSADO 399 000324\r\n</STMTTRN>\r\n<STMTTRN>\r\n<TRNTYPE>CREDIT\r\n<DTPOSTED>20140219100000[-03:EST]\r\n<TRNAMT>3001.06" +
                           "\r\n<MEMO>INT RESGATE   SPECIAL RF\r\n</STMTTRN>\r\n</BANKTRANLIST>\r\n<LEDGERBAL>\r\n<BALAMT>-4021.44\r\n<DTASOF>20140318100000[-03:EST]" +
                           "\r\n</LEDGERBAL>\r\n</STMTRS>\r\n</STMTTRNRS>\r\n</BANKMSGSRSV1>\r\n</OFX>";

            return template;
        }
        #endregion
    }
}