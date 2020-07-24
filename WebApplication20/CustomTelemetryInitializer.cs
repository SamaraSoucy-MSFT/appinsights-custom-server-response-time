using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using WebApplication20;

public class TelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry == null)
        {
            throw new ArgumentNullException(nameof(telemetry));
        }
        telemetry.Context.Component.Version = "2";

        switch (telemetry)
        {
            case RequestTelemetry requestTelemetry:
                {
                    AddTlsLoggingTelemetry(requestTelemetry);
                    break;
                }
            case MetricTelemetry metricTelemetry:
                {
                    if (metricTelemetry.Name == "Server response time" 
                        && metricTelemetry.Context.GlobalProperties.ContainsKey("_MS.IsAutocollected")) {
                        var client = new TelemetryClient();
                        var metricCopy = metricTelemetry.DeepClone() as MetricTelemetry;
                        metricCopy.Context.GlobalProperties.Remove("_MS.IsAutocollected");
                        metricCopy.Context.GlobalProperties.Remove("_MS.MetricId");
                        metricCopy.Context.GlobalProperties.Add("foo", "bar");
                        //metricCopy.Name = "Custom server response time";
                        client.TrackMetric(metricCopy);
                    }

                    break;
                }
        }
    }

    private void AddTlsLoggingTelemetry(RequestTelemetry telemetry)
    {
        /* Some custom properties addition */
    }
}