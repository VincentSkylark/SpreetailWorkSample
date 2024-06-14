﻿using SpreetailWorkSample.MultiDictionary;
using SpreetailWorkSample.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreetailWorkSample.Commands
{
    internal class ItemsCommand : ICommand
    {
        private readonly IMultiDictionaryService _multiDictionaryService;

        public ItemsCommand(IMultiDictionaryService service)
        {
            _multiDictionaryService = service;
        }
        public void Execute(string?[] args)
        {
            if (args != null && args.Length > 0)
            {
                ConsoleUtility.InvalidArguments(0);
                return;
            }
            _multiDictionaryService.Items();
        }

    }
}