function doLongRunningThing(context) {
    return new Promise( (resolve, reject) => {
        setTimeout( () => {     
            context.log("timer complete")       
            resolve()
        }, 2000)
    })
}

module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    await doLongRunningThing(context)

    context.res = {
        // status: 200, /* Defaults to 200 */
        body: "Hello"
    };
    context.log("about to call done")
};