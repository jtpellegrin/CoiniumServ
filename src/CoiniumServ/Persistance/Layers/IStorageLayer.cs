﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion

using System;
using System.Collections.Generic;
using CoiniumServ.Miners;
using CoiniumServ.Payments;
using CoiniumServ.Persistance.Blocks;
using CoiniumServ.Shares;

namespace CoiniumServ.Persistance.Layers
{
    public interface IStorageLayer
    {

        #region share storage

        bool SupportsShareStorage { get; }

        void AddShare(IShare share);

        void RemoveShares(IPaymentRound round);

        Dictionary<string, double> GetCurrentShares();

        Dictionary<UInt32, Dictionary<string, double>> GetShares(IList<IPaymentRound> rounds);

        #endregion

        #region block storage

        bool SupportsBlockStorage { get; }

        void AddBlock(IShare share);

        void UpdateBlock(IPaymentRound round);

        IDictionary<string, int> GetTotalBlocks();

        IEnumerable<IPersistedBlock> GetBlocks(BlockStatus status);

        #endregion

        #region user storage

        bool Authenticate(IMiner miner);

        #endregion

        #region payments storage

        bool SupportsPaymentsStorage { get; }

        #endregion
    }
}
