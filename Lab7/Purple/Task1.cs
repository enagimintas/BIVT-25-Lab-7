namespace Lab7.Purple
{
    public class Task1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpCount;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coeff => (double[])_coefs.Clone();
            public int[,] Marks => (int[,])_marks.Clone();
             
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                _marks = new int[4, 7];
                _jumpCount = 0;

                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = 2.5;
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }
            }

            public double TotalScore()
            {
                double total = 0;
                for (int i = 0; i < 4; i++)
                {
                    int sum = 0, min = 0, max = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        int mark = _marks[i, j];
                        sum += mark;
                        if (mark < min) min = mark;
                        if (mark > max) max = mark;
                    }
                    total += (sum - min - max) * _coefs[i];
                }
                return total;
            }

            public void SetCriterias(double[] coefs)
            {
                if (!coefs || coefs.Length != 4)
                    return;

                _coefs = coefs;
            }

            public void Jump(int[] marks)
            {
                if (_jumpCount < 4 && marks.Length == 7)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[_jumpCount, j] = marks[j];
                    }
                    _jumpCount++;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_surname} {_name}: {TotalScore()}");
            }

            public void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalScore() < array[j].TotalScore())
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
    }
}