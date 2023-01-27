using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    class Disjoint
    {
        public long[] rank, parent;
        long n;

        public Disjoint(long n)
        {
            rank = new long[n];
            parent = new long[n];
            this.n = n;
            makeSet();
        }
        public void makeSet()
        {
            for (long i = 0; i < n; i++) parent[i] = i;
        }
    
        public long find(long x)
        {
            if (parent[x] != x) parent[x] = find(parent[x]);   
            return parent[x];
        }

        public void union(long start, long end)
        {
            long sNeighbor = find(start);
            long eNeighbor = find(end);

            if (sNeighbor == eNeighbor) return;

            if (rank[sNeighbor] < rank[eNeighbor]) parent[sNeighbor] = eNeighbor;

            else if (rank[eNeighbor] < rank[sNeighbor]) parent[eNeighbor] = sNeighbor;
    
            else 
            {
                parent[eNeighbor] = sNeighbor;
                rank[sNeighbor] = rank[sNeighbor] + 1;
            }
        }
    }
}
