using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xayah.Finances.Business.Common.Extensions;
using Xayah.Finances.Domain.Accounts.Transactions;

namespace Xayah.Finances.Business.Services
{
    public partial class AccountService
    {
        private async Task<List<Transaction>> CreateTransactions(StreamReader reader)
        {
            var transactions = new List<Transaction>();

            var line = await reader.ReadLineAsync();

            while (!line.StartsWith("</BANKTRANLIST>"))
            {
                if (line.StartsWith("<STMTTRN>"))
                {
                    var transaction = await CreateTransaction(reader);

                    transactions.Add(transaction);
                }

                line = await reader.ReadLineAsync();
            }

            return transactions;
        }

        private async Task<Transaction> CreateTransaction(StreamReader reader)
        {
            var typeLine = await reader.ReadLineAsync();
            var dateLine = await reader.ReadLineAsync();
            var valueLine = await reader.ReadLineAsync();
            var descriptionLine = await reader.ReadLineAsync();

            var type = typeLine.GetValueLine();
            var date = dateLine.GetValueDateLine();
            var value = Convert.ToDecimal(valueLine.GetValueLine().Replace(".", ","));
            var description = descriptionLine.GetValueLine();

            var transaction = Transaction.Create(type, description, date, value);

            return transaction;
        }
    }
}