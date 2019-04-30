using OPTANO.Modeling.Common;
using OPTANO.Modeling.Optimization;
using OPTANO.Modeling.Optimization.Configuration;
using OPTANO.Modeling.Optimization.Enums;
using OPTANO.Modeling.Optimization.Solver.GLPK;
using System.Collections.Generic;

namespace Otimizacao
{
    public class Modelo
    {
        public static List<string> Solve(int Vi, int Vf)
        {
            var config = new Configuration
            {
                NameHandling = NameHandlingStyle.Manual
            };

            var path = new List<string>();

            using (var scope = new ModelScope(config))
            {
                var model = new Model();

                #region Variáveis
                var x = new Variable[62];
                x[0] = new Variable("0-6", 0, 1, VariableType.Binary);
                x[1] = new Variable("6-0", 0, 1, VariableType.Binary);
                x[2] = new Variable("1-7", 0, 1, VariableType.Binary);
                x[3] = new Variable("7-1", 0, 1, VariableType.Binary);
                x[4] = new Variable("2-7", 0, 1, VariableType.Binary);
                x[5] = new Variable("7-2", 0, 1, VariableType.Binary);
                x[6] = new Variable("2-3", 0, 1, VariableType.Binary);
                x[7] = new Variable("3-2", 0, 1, VariableType.Binary);
                x[8] = new Variable("2-14", 0, 1, VariableType.Binary);
                x[9] = new Variable("14-2", 0, 1, VariableType.Binary);
                x[10] = new Variable("3-4", 0, 1, VariableType.Binary);
                x[11] = new Variable("4-3", 0, 1, VariableType.Binary);
                x[12] = new Variable("3-8", 0, 1, VariableType.Binary);
                x[13] = new Variable("8-3", 0, 1, VariableType.Binary);
                x[14] = new Variable("3-15", 0, 1, VariableType.Binary);
                x[15] = new Variable("15-3", 0, 1, VariableType.Binary);
                x[16] = new Variable("4-9", 0, 1, VariableType.Binary);
                x[17] = new Variable("9-4", 0, 1, VariableType.Binary);
                x[18] = new Variable("5-9", 0, 1, VariableType.Binary);
                x[19] = new Variable("9-5", 0, 1, VariableType.Binary);
                x[20] = new Variable("6-7", 0, 1, VariableType.Binary);
                x[21] = new Variable("7-6", 0, 1, VariableType.Binary);
                x[22] = new Variable("6-13", 0, 1, VariableType.Binary);
                x[23] = new Variable("13-6", 0, 1, VariableType.Binary);
                x[24] = new Variable("7-14", 0, 1, VariableType.Binary);
                x[25] = new Variable("14-7", 0, 1, VariableType.Binary);
                x[26] = new Variable("8-9", 0, 1, VariableType.Binary);
                x[27] = new Variable("9-8", 0, 1, VariableType.Binary);
                x[28] = new Variable("9-10", 0, 1, VariableType.Binary);
                x[29] = new Variable("10-9", 0, 1, VariableType.Binary);
                x[30] = new Variable("10-11", 0, 1, VariableType.Binary);
                x[31] = new Variable("11-10", 0, 1, VariableType.Binary);
                x[32] = new Variable("11-12", 0, 1, VariableType.Binary);
                x[33] = new Variable("12-11", 0, 1, VariableType.Binary);
                x[34] = new Variable("13-14", 0, 1, VariableType.Binary);
                x[35] = new Variable("14-13", 0, 1, VariableType.Binary);
                x[36] = new Variable("13-17", 0, 1, VariableType.Binary);
                x[37] = new Variable("17-13", 0, 1, VariableType.Binary);
                x[38] = new Variable("14-15", 0, 1, VariableType.Binary);
                x[39] = new Variable("15-14", 0, 1, VariableType.Binary);
                x[40] = new Variable("15-16", 0, 1, VariableType.Binary);
                x[41] = new Variable("16-15", 0, 1, VariableType.Binary);
                x[42] = new Variable("16-8", 0, 1, VariableType.Binary);
                x[43] = new Variable("8-16", 0, 1, VariableType.Binary);
                x[44] = new Variable("16-18", 0, 1, VariableType.Binary);
                x[45] = new Variable("18-16", 0, 1, VariableType.Binary);
                x[46] = new Variable("16-20", 0, 1, VariableType.Binary);
                x[47] = new Variable("20-16", 0, 1, VariableType.Binary);
                x[48] = new Variable("17-18", 0, 1, VariableType.Binary);
                x[49] = new Variable("18-17", 0, 1, VariableType.Binary);
                x[50] = new Variable("18-19", 0, 1, VariableType.Binary);
                x[51] = new Variable("19-18", 0, 1, VariableType.Binary);
                x[52] = new Variable("18-20", 0, 1, VariableType.Binary);
                x[53] = new Variable("20-18", 0, 1, VariableType.Binary);
                x[54] = new Variable("20-10", 0, 1, VariableType.Binary);
                x[55] = new Variable("10-20", 0, 1, VariableType.Binary);
                x[56] = new Variable("19-21", 0, 1, VariableType.Binary);
                x[57] = new Variable("21-19", 0, 1, VariableType.Binary);
                x[58] = new Variable("21-22", 0, 1, VariableType.Binary);
                x[59] = new Variable("22-21", 0, 1, VariableType.Binary);
                x[60] = new Variable("22-11", 0, 1, VariableType.Binary);
                x[61] = new Variable("11-22", 0, 1, VariableType.Binary);
                #endregion

                // Função Objetivo
                // Cada aresta/caminho multiplicada pelo seu respectivo peso/distância
                model.AddObjective(new Objective(
                    13.09 * x[0] + 13.09 * x[1] + 24.95 * x[2] + 24.95 * x[3] + 43.69 * x[4] + 43.69 * x[5] + 64.94 * x[6] +
                    64.94 * x[7] + 57.19 * x[8] + 57.19 * x[9] + 33.41 * x[10] + 33.41 * x[11] + 27.13 * x[12] +
                    27.13 * x[13] + 62.32 * x[14] + 62.32 * x[15] + 31.40 * x[16] + 31.40 * x[17] + 36.02 * x[18] +
                    36.02 * x[19] + 42.67 * x[20] + 42.67 * x[21] + 20.27 * x[22] + 20.27 * x[23] + 26.97 * x[24] +
                    26.97 * x[25] + 32.04 * x[26] + 32.04 * x[27] + 13.91 * x[28] + 13.91 * x[29] + 28.93 * x[30] +
                    28.93 * x[31] + 30.26 * x[32] + 30.26 * x[33] + 32.60 * x[34] + 32.60 * x[35] + 35.74 * x[36] +
                    35.74 * x[37] + 25.98 * x[38] + 25.98 * x[39] + 22.58 * x[40] + 22.58 * x[41] + 67.90 * x[42] +
                    67.90 * x[43] + 48.42 * x[44] + 48.42 * x[45] + 36.17 * x[46] + 36.17 * x[47] + 42.37 * x[48] +
                    42.37 * x[49] + 13.91 * x[50] + 13.91 * x[51] + 53.51 * x[52] + 53.51 * x[53] + 98.91 * x[54] +
                    98.91 * x[55] + 38.14 * x[56] + 38.14 * x[57] + 97.51 * x[58] + 97.51 * x[59] + 37.28 * x[60] +
                    37.28 * x[61]
                , string.Empty, ObjectiveSense.Minimize));

                #region Restrições
                // Para cada vértice, as arestas de entrada são positivas e as de saída são negativas
                // Valor da expressão
                int value = 0;
                // 0
                value = Vi == 0 ? -1 : Vf == 0 ? 1 : 0;
                model.AddConstraint(x[1] - x[0] == value);
                // 1
                value = Vi == 1 ? -1 : Vf == 1 ? 1 : 0;
                model.AddConstraint(x[3] - x[2] == value);
                // 2
                value = Vi == 2 ? -1 : Vf == 2 ? 1 : 0;
                model.AddConstraint(x[7] + x[9] + x[5] - x[6] - x[8] - x[4] == value);
                // 3
                value = Vi == 3 ? -1 : Vf == 3 ? 1 : 0;
                model.AddConstraint(x[11] + x[13] + x[15] + x[6] - x[10] - x[12] - x[14] - x[7] == value);
                // 4
                value = Vi == 4 ? -1 : Vf == 4 ? 1 : 0;
                model.AddConstraint(x[17] + x[10] - x[16] - x[11] == value);
                // 5 
                value = Vi == 5 ? -1 : Vf == 5 ? 1 : 0;
                model.AddConstraint(x[19] - x[18] == value);
                // 6
                value = Vi == 6 ? -1 : Vf == 6 ? 1 : 0;
                model.AddConstraint(x[0] + x[23] + x[21] - x[1] - x[22] - x[20] == value);
                // 7
                value = Vi == 7 ? -1 : Vf == 7 ? 1 : 0;
                model.AddConstraint(x[20] + x[2] + x[25] + x[4] - x[21] - x[3] - x[24] - x[5] == value);
                // 8 
                value = Vi == 8 ? -1 : Vf == 8 ? 1 : 0;
                model.AddConstraint(x[42] + x[27] + x[12] - x[43] - x[26] - x[13] == value);
                // 9
                value = Vi == 9 ? -1 : Vf == 9 ? 1 : 0;
                model.AddConstraint(x[29] + x[16] + x[26] + x[18] - x[28] - x[17] - x[27] - x[19] == value);
                // 10
                value = Vi == 10 ? -1 : Vf == 10 ? 1 : 0;
                model.AddConstraint(x[31] + x[54] + x[28] - x[30] - x[55] - x[29] == value);
                // 11
                value = Vi == 11 ? -1 : Vf == 11 ? 1 : 0;
                model.AddConstraint(x[60] + x[30] + x[33] - x[61] - x[31] - x[32] == value);
                // 12
                value = Vi == 12 ? -1 : Vf == 12 ? 1 : 0;
                model.AddConstraint(x[32] - x[33] == value);
                // 13
                value = Vi == 13 ? -1 : Vf == 13 ? 1 : 0;
                model.AddConstraint(x[22] + x[37] + x[35] - x[23] - x[36] - x[34] == value);
                // 14
                value = Vi == 14 ? -1 : Vf == 14 ? 1 : 0;
                model.AddConstraint(x[39] + x[34] + x[24] - x[38] - x[35] - x[25] == value);
                // 15
                value = Vi == 15 ? -1 : Vf == 15 ? 1 : 0;
                model.AddConstraint(x[14] + x[38] + x[41] - x[15] - x[39] - x[40] == value);
                // 16
                value = Vi == 16 ? -1 : Vf == 16 ? 1 : 0;
                model.AddConstraint(x[43] + x[40] + x[47] + x[45] - x[42] - x[41] - x[46] - x[44] == value);
                // 17
                value = Vi == 17 ? -1 : Vf == 17 ? 1 : 0;
                model.AddConstraint(x[36] + x[49] - x[37] - x[48] == value);
                // 18
                value = Vi == 18 ? -1 : Vf == 18 ? 1 : 0;
                model.AddConstraint(x[48] + x[51] + x[53] + x[44] - x[49] - x[50] - x[52] - x[45] == value);
                // 19
                value = Vi == 19 ? -1 : Vf == 19 ? 1 : 0;
                model.AddConstraint(x[50] + x[57] - x[51] - x[56] == value);
                // 20
                value = Vi == 20 ? -1 : Vf == 20 ? 1 : 0;
                model.AddConstraint(x[52] + x[46] + x[55] - x[53] - x[47] - x[54] == value);
                // 21
                value = Vi == 21 ? -1 : Vf == 21 ? 1 : 0;
                model.AddConstraint(x[56] + x[59] - x[57] - x[58] == value);
                // 22
                value = Vi == 22 ? -1 : Vf == 22 ? 1 : 0;
                model.AddConstraint(x[58] + x[61] - x[59] - x[60] == value);

                #region Condições de não-negatividade
                x.ForEach(variable =>
                {
                    model.AddConstraint(variable >= 0);
                });
                #endregion
                #endregion

                using (var solver = new GLPKSolver())
                {
                    var solution = solver.Solve(model);                    

                    x.ForEach(variable =>
                    {
                        if (variable.Value != 0)
                            path.Add(variable.Name);
                    });
                }
            }

            return path;
        }
    }
}
