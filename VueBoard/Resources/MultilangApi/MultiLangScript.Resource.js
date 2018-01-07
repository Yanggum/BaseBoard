
var MultiLanguageScript = '';

function SetCurrentLanguage(languageCode) {
	languageCode = languageCode.toLowerCase();
    switch (languageCode) {
        case "ko":
            MultiLanguageScript = MULTI_LANG_KO;
            break;

        case "en":
            MultiLanguageScript = MULTI_LANG_EN;
            break;

        default:
            MultiLanguageScript = MULTI_LANG_KO;
            break;
    }
}

function GetMultiLanguage(key){
	return MultiLanguageScript[key];
}

function SetLanguage(currentLanguage)
{
    $('[data-langKey]').each(function()
    {
        var $this = $(this);
        $this.text(currentLanguage[$this.data('langkey')]);
    })
}


var MULTI_LANG_KO = {	
	"Comment" : "댓글",
}

var MULTI_LANG_EN = {	
	"Comment" : "Comment",
}

{
    var langcode = 'ko'
    if (typeof (gWebInfo) != 'undefined') { langcode = gWebInfo.GwpLangCode; }
    SetCurrentLanguage(langcode);
}