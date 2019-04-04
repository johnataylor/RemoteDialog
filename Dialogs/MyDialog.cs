// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Designer.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace RemoteDialog.Dialogs
{
    public class MyDialog : FunctionDialogBase
    {
        private static string[] Messages = { "one", "two", "three" };

        public MyDialog()
            : base(nameof(MyDialog))
        {
        }

        protected override Task<(object newState, IEnumerable<Activity> output, object result)> ProcessAsync(object oldState, Activity input)
        {
            // This is a simple dialog that counts up to three and then finishes.
            // When it finishes the bot kicks it off again with the next utterance.

            int index = (int)(oldState ?? 0);

            var response = new Activity[] { MessageFactory.Text($"{Messages[index]} {input.Text}") };

            if (++index == 3)
            {
                index = 0;
            }
            
            return Task.FromResult(((object)index, (IEnumerable<Activity>)response, (object)null));
        }
    }
}
