module.exports = function (context, req, thesecret) {
    context.log('Here is the secret url...');

    context.log(thesecret);

    context.done();
};