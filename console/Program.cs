using System;

namespace fcfs_scheduling
{
	class Program
	{
		public static void Main(String[] args)
		{
			int[] processes = new int[100];
			Console.WriteLine("enter number of process:");
			int n = int.Parse(Console.ReadLine());
			int[] burst_time = new int[100];
			Console.WriteLine("enter burst time of process:");
			for (int i = 0; i < n; i++)
			{
				burst_time[i] = int.Parse(Console.ReadLine());
			}
			int[] arrival_time = new int[100];
			Console.WriteLine("enter arrival time of process:");
			for (int i = 0; i < n; i++)
			{
				arrival_time[i] = int.Parse(Console.ReadLine());
			}
			findavgTime(processes, n, burst_time, arrival_time);

		}
		static void findWaitingTime(int[] processes, int n, int[] bt, int[] wt, int[] arri)
		{
			int[] start_time = new int[n];
			start_time[0] = 0;
			wt[0] = 0;
			for (int i = 1; i < n; i++)
			{
				start_time[i] = start_time[i - 1] + bt[i - 1];
				wt[i] = start_time[i] - arri[i];
				if (wt[i] < 0)
				{
					wt[i] = 0;
				}
			}
		}

		static void findTurnAroundTime(int[] processes, int n, int[] bt, int[] wt, int[] turn)

		{
			for (int i = 0; i < n; i++)
			{
				turn[i] = bt[i] + wt[i];
			}
		}
		static void findavgTime(int[] processes, int n, int[] bt, int[] arri)
		{
			int[] wt = new int[n];
			int[] turn = new int[n];
			findWaitingTime(processes, n, bt, wt, arri);
			findTurnAroundTime(processes, n, bt, wt, turn);
			Console.Write("Processes " + "  Burst Time " + " Arrival Time "
				+ " Waiting Time " + " Turn-Around Time "
				+ " finished time \n");
			int total_wt = 0;
			int total_turn = 0;
			for (int i = 0; i < n; i++)
			{
				total_wt = total_wt + wt[i];
				total_turn = total_turn + turn[i];
				int finished_time = turn[i] + arri[i];
				Console.WriteLine((i + 1) + " \t\t " + bt[i] + " \t\t "
					+ arri[i] + " \t\t " + wt[i] + " \t\t "
					+ turn[i] + "\t\t" + finished_time);

			}
			Console.WriteLine(" total waiting time = " + total_wt);
			Console.WriteLine(" Average waiting time = " + total_wt / n);
			Console.WriteLine(" total turn around time = " + total_turn);
			Console.WriteLine(" Average turn around time = " + total_turn / n);
		}
	}
}
