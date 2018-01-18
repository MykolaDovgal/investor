let viewSelector = null;
let timeline = null;

let newTimelineOption = {
    reportType: 'ga',
    query: {
        'dimensions': 'ga:date',
        'metrics': 'ga:sessions',
        'start-date': '30daysAgo',
        'end-date': 'yesterday',
    },
    chart: {
        type: 'LINE',
        container: 'timeline'
    }
};

let initialGoogleAnalyticsDashboard = function () {

    if (viewSelector && timeline) {
        viewSelector.execute();
        timeline = new gapi.analytics.googleCharts.DataChart(newTimelineOption);
        return;
    }

    const clientId = '565347094570-46d26vk6cbpknqfh6aiu3l8btr8lde5h.apps.googleusercontent.com';

    gapi.analytics.auth.authorize({
        container: 'auth-button',
        clientid: clientId
    });

    // Step 4: Create the view selector.

    viewSelector = new gapi.analytics.ViewSelector({
        container: 'view-selector'
    });

    // Step 5: Create the timeline chart.

    timeline = new gapi.analytics.googleCharts.DataChart(newTimelineOption);

    // Step 6: Hook up the components to work together.

    gapi.analytics.auth.on('success', function (response) {
        viewSelector.execute();
    });

    viewSelector.on('change', function (ids) {
        console.log(ids);
        var newIds = {
            query: {
                ids: ids
            }
        }
        timeline.set(newIds).execute();
    });

};
