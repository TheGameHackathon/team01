﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var numberOfColors = 5;

            CellDto[] testCells = new CellDto[width*height];
            Random random = new Random();
            for (int i = 0; i < width*height; i++)
            {
                testCells[i] = new CellDto((i+1).ToString(), new Vec(i%height, i/width), "color" + random.Next(0,numberOfColors-1), "", 0);
            }

            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }

        
    }
}