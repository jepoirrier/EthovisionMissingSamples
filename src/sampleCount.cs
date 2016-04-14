using System;

namespace EthoVisionTrackMissingSamples
{
	/// <summary>
	/// Keeps track of total number of samples and number of mised samples
	/// </summary>
	public class sampleCount
	{
		private int totsamples = 0; // Total number of samples
		private int nmissed = 0;    // Total number of missed samples
		private double samplerate = 0; // Specify the sample rate
		private double theoreticalduration = 0; // Will specify the theoretical duration (read from file)

		public sampleCount()
		{
			// We don't initialize anything in this constructor
		}

		public void setTotalSamples(int n)
		{
			// Method to set the total number of samples in one go
			totsamples = n;
		}

		public int getTotalSamples()
		{
			// Method that returns the total number of samples in the track (int)
			return totsamples;
		}

		public void addOneMissed()
		{
			// Method to add one missed sample to the total number of missed samples
			nmissed++;
		}

		public int getNMissed()
		{
			// Method that returns the number of missed samples
			return nmissed;
		}

		public void resetNMissed()
		{
			// Method to reset the number of missed samples
			nmissed = 0;
		}

		public void setSR(double n)
		{
			// Method that set the sample rate
			samplerate = n;
		}

		public void setTheoreticalDuration(double n)
		{
			// Method that set the duration read in the file --- needed to compute the guessed samplerate
			theoreticalduration = n;
		}

		public double getGuessedSampleRate()
		{
			// Method that returns the guessed sample rate, from totalsample > 0 and theoreticalduration > 0
			if(totsamples > 0 && theoreticalduration > 0)
				return (Convert.ToDouble(totsamples) / theoreticalduration);
			else
				return 0;
		}

		private double getTime(int ns)
		{
			// General method that returns the time according to n (number of samples) and samplerate
			// Needs n > 0 and samplerate > 0

			double n = 0;

			if(ns > 0 && samplerate > 0)
				n = Convert.ToDouble(ns) / samplerate;

			return n;
		}

		public double getTotalDuration()
		{
			// Method that returns the total duration (float) (in seconds)
			return getTime(totsamples);
		}

		public double getMissedDuration()
		{
			// Method that returns the duration of missed samples (float) (in seconds)
			return getTime(nmissed);
		}

		public double getPercentageMissed()
		{
			// Method that returns the percentage of missed samples (float)
			// Needs totsamples > 0 and nmissed > 0
			double n = 0;

			if(totsamples > 0 && nmissed > 0)
				n = Convert.ToDouble(nmissed) * 100 / Convert.ToDouble(totsamples);

			return n;
		}
	}
}
