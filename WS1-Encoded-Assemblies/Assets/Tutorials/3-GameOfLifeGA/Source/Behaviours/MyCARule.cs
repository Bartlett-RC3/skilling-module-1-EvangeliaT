using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    namespace WS2
    {
        /// <summary>
        /// Rule for Conway's game of life
        /// </summary>
        [RequireComponent(typeof(StackModel))]
        [RequireComponent(typeof(StackAnalyser))]
        public class MyCARule : MonoBehaviour, ICARule2D
        {
            private StackModel _model;
            private StackAnalyser _analyser;

            //setup some possible instruction sets
            private GOLInstructionSet _instSetMO1 = new GOLInstructionSet(1, 2, 3, 4);
            private GOLInstructionSet _instSetMO2 = new GOLInstructionSet(2, 3, 3, 3);
            private GOLInstructionSet _instSetMO3 = new GOLInstructionSet(2, 3, 3, 4);
            /*
            public GOLInstructionSet[] instructionSetArray;

            private GOLInstructionSet _instSetMO1 = new GOLInstructionSet(1, 2, 3, 4);
            private GOLInstructionSet _instSetMO2 = new GOLInstructionSet(2, 3, 3, 3);
            private GOLInstructionSet _instSetMO3 = new GOLInstructionSet(2, 3, 3, 4);
            private GOLInstructionSet _instSetMO4 = new GOLInstructionSet(3, 3, 3, 8);
            private GOLInstructionSet _instSetMO5 = new GOLInstructionSet(4, 5, 3, 4);
            private GOLInstructionSet _instSetMO6 = new GOLInstructionSet(4, 6, 3, 5);
            private GOLInstructionSet _instSetMO7 = new GOLInstructionSet(5, 7, 3, 5);
            private GOLInstructionSet _instSetMO8 = new GOLInstructionSet(6, 8, 6, 2);
            */


            private IDNAF _dna;

      
            /// <summary>
            /// 
            /// </summary>
            private void Start()
            {
                _model = GetComponent<StackModel>();
                _analyser = GetComponent<StackAnalyser>();
                _dna = _model.Stack.DNA;

                /*
                instructionSetArray = new GOLInstructionSet[5];

                instructionSetArray[0] = _instSetMO1;
                instructionSetArray[1] = _instSetMO2;
                instructionSetArray[2] = _instSetMO3;
                instructionSetArray[3] = _instSetMO5;
                instructionSetArray[4] = _instSetMO8;
                */
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="i"></param>
            /// <param name="j"></param>
            /// <param name="current"></param>
            /// <returns></returns>
            public int NextAt(Index2 index, int[,] current)
            {
                //get current state
                int state = current[index.I, index.J];

                //get local neighborhood data
                int sumMO = GetNeighborSum(index, current, Neighborhoods.MooreR1);
                int sumVNPair = GetNeighborSum(index, current, Neighborhoods.VonNeumannPair1);

                //choose an instruction set
                GOLInstructionSet instructionSet = _instSetMO1;

               // GOLInstructionSet instr1 = instructionSetArray[Mathf.RoundToInt(_dna.GetGene(0))];
                //GOLInstructionSet instr2 = instructionSetArray[Mathf.RoundToInt(_dna.GetGene(1))];
                //float densityThreshhold = _dna.GetGene(2);

                // collect relevant analysis results
                CellLayer[] layers = _model.Stack.Layers;
                int currentLayer = _model.CurrentLayer;

                float prevLayerDensity;
                int prevCellAge;

                // get attributes of corresponding cell on the previous layer (if it exists)
                if (currentLayer > 0)
                {
                    var prevLayer = layers[currentLayer - 1];
                    prevLayerDensity = prevLayer.Density;
                    prevCellAge = prevLayer.Cells[index.I, index.J].Age;
                }
                else
                {
                    prevLayerDensity = 1.0f;
                    prevCellAge = 0;
                }

                /*
                if (currentlayerdensity < .17)
                {
                    instructionSet = _instSetMO3;
                }

                if (currentlayerdensity >= .17 && currentlayerdensity<.2)
                {
                    instructionSet = _instSetMO1;
                }

                if (currentlayerdensity >.2)
                {
                    instructionSet = _instSetMO2;
                }
                */

                /*
                if(state==0 && sumVNPair == 2)
                {
                    return 1;
                }

                if (state == 1 && sumVNPair == 2)
                {
                    return 0;
                }
                */


                /*
                if(currentlevel <= 40)
                {
                    instructionSet = _instSetMO1;
                }

                if (currentlevel > 40 && currentlevel<65)
                {
                    instructionSet = _instSetMO2;
                }

                if (currentlevel >= 65)
                {
                    instructionSet = _instSetMO3;
                }
                */


                //float density = _analyser.MeanStackDensity;


                //Change the Model with Mean Stack Density                

                /*
                if (density > densityThreshhold)
                {
                    instructionSet = instr1;
                }
                else
                {
                    instructionSet = instr2;
                }



                if (currentLayer == 39)
                {
                    Debug.Log("current layer is: " + currentLayer);
                    //Debug.Log($"Density GA Threshold: {densityThreshhold}");
                    Debug.Log("density is: " + density);
                }
                */

                int output = 0;

                //if current state is "alive"
                if (state == 1)
                {
                    if (sumMO < instructionSet.getInstruction(0))
                    {
                        output = 0;
                    }

                    if (sumMO >= instructionSet.getInstruction(0) && sumMO <= instructionSet.getInstruction(1))
                    {
                        output = 1;
                    }

                    if (sumMO > instructionSet.getInstruction(1))
                    {
                        output = 0;
                    }
                }

                //if current state is "dead"
                if (state == 0)
                {
                    if (sumMO >= instructionSet.getInstruction(2) && sumMO <= instructionSet.getInstruction(3))
                    {
                        output = 1;
                    }
                    else
                    {
                        output = 0;
                    }
                }

                return output;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="i0"></param>
            /// <param name="j0"></param>
            /// <returns></returns>
            private int GetNeighborSum(Index2 index, int[,] current, Index2[] neighborhood)
            {
                int nrows = current.GetLength(0);
                int ncols = current.GetLength(1);
                int sum = 0;

                foreach (Index2 offset in neighborhood)
                {
                    int i1 = Wrap(index.I + offset.I, nrows);
                    int j1 = Wrap(index.J + offset.J, ncols);

                    if (current[i1, j1] > 0)
                        sum++;
                }

                return sum;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="i"></param>
            /// <param name="n"></param>
            /// <returns></returns>
            private static int Wrap(int i, int n)
            {
                i %= n;
                return (i < 0) ? i + n : i;
            }
        }
    }
}