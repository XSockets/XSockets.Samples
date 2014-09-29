## XSockets.Samples - Scaling and Performance Counters

A basic example of how to scale with XSockets.

The sample is made "how to" scale, it is not built for best performance since we run all servers and clients on the same machine.
To test performance for scaling you should host servers on several machines and clients should also be on another machine.

### Pre req
To get performance counters you need to install the XSockets.PerformanceCounters from chocolatey
http://chocolatey.org/packages/XSockets.PerformanceCounters

### Running the sample
To test the sample start the project in the following order
(Note: starting without debug will increase performance)

- Open perfmon.exe and add the XSockets performance counter for OUT/SEC
- Start server projects  ServerA, ServerB, ServerC, ServerD
- Start the Clients project (when started, hit enter to connect clients)
- Start the Web project
  Then change settings teh way you want them in the UI and hit the button to start the test.

### Images
![Add PerfCounter](http://xsockets.net/$2/file/scaling1.png)
![Test In Progress](http://xsockets.net/$2/file/scaling2.png)
![Test Completed](http://xsockets.net/$2/file/scaling3.png)