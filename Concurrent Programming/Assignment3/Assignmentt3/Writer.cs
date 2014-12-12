//Markus Olsson, AB7158
//Concurrent Programming, Assignment 3
using System.Collections.Generic;

namespace Assignmentt3
{
    public class Writer
    {

        private List<string> textToWrite;
        private CircleBuffer buffer;

        public Writer(CircleBuffer piBufferIn, List<string> piTextIn)
        {
            this.textToWrite = piTextIn;
            this.buffer = piBufferIn;
        }

        public void Write()
        {
            int localcount = 0;
            while(localcount < textToWrite.Count)
            {
                buffer.Write(textToWrite[localcount], localcount);
                localcount++;
            }
        }
    }
}
