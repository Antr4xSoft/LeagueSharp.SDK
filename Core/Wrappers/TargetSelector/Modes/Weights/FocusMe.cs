﻿// <copyright file="FocusMe.cs" company="LeagueSharp">
//    Copyright (c) 2015 LeagueSharp.
// 
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
// 
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
// 
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/
// </copyright>

namespace LeagueSharp.SDK.Core.Wrappers.TargetSelector.Modes.Weights
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     Focus Me
    /// </summary>
    public class FocusMe : IWeightItem
    {
        #region Public Properties

        public int DefaultWeight => 0;

        public string DisplayName => "Focus Me";

        /// <summary>
        ///     Gets or sets the fade time.
        /// </summary>
        /// <value>
        ///     The fade time.
        /// </value>
        public int FadeTime { get; set; } = 10000;

        public bool Inverted => false;

        public string Name => "focus-me";

        #endregion

        #region Public Methods and Operators

        public float GetValue(Obj_AI_Hero hero)
        {
            var entry = Aggro.GetSenderTargetItem(hero, ObjectManager.Player);
            return entry != null ? Math.Max(0, this.FadeTime - (Variables.TickCount - entry.TickCount)) : 0;
        }

        #endregion
    }
}