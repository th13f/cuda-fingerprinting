﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexFilterQA;
using FingerprintLib;

namespace ModelBasedAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Tanya\\Documents\\tests_data\\101_1.tif";

            double[,] imgBytes = ImageHelper.LoadImage(path);
            imgBytes = ImageEnhancementHelper.EnhanceImage(imgBytes);

            // size ~ 2.3
            double[,] orientationField = PixelwiseOrientationFieldGenerator.GenerateOrientationField(imgBytes);

            // List<Point> singularPoints = PoincareIndexMethod.FindSingularPoins(orientationField);
            List<Tuple<int, int>> singularPoints = new List<Tuple<int, int>>();
            singularPoints.Add(new Tuple<int,int>(40, 40));

            singularPoints = ModelBasedAlgorithm.FindSingularPoints(orientationField, singularPoints);
        }
    }
}
