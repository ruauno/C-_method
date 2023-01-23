        public static IEnumerable<(DateTime Start, DateTime End)> GetConsecutivePeriods(List<DateTime> lst)
        {
            lst = lst.OrderBy(a => a).Distinct().ToList();
            if (lst == null || lst.Count == 0) yield break;

            var isConseguitivo = true;
            var inizioRange = 0;
            var fineRange = 0;
            for (var i = 0; i < lst.Count; i++)
            {
                var first = i == 0;
                var last = i == lst.Count - 1;
                if (!first && lst[i - 1] == lst[i].AddDays(-1))
                    isConseguitivo = true;
                else if (!first)
                    isConseguitivo = false;
                if (!isConseguitivo && !first && !last)
                {
                    fineRange = !first && !last ? i - 1 : i;
                    yield return (lst[inizioRange], lst[fineRange]);
                    inizioRange = i;
                }
                else if (last)
                {
                    if (!isConseguitivo)
                    {
                        if (!first)
                            fineRange = i - 1;
                        yield return (lst[inizioRange], lst[fineRange]);
                        inizioRange = i;
                    }
                    fineRange = i;
                    yield return (lst[inizioRange], lst[fineRange]);
                }
            }
        }
