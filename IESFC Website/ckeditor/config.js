/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    //config for mathjax. 
    config.mathJaxLib = 'https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-MML-AM_CHTML';

    //config for size. 
    config.height = '450px';

    // config for smileys. 
    config.smiley_path = '/shit/';
    config.smiley_columns = 4;
    config.smiley_images = [
        '1.gif', '2.gif', '3.gif', '4.gif', '5.gif', '6.gif', '7.gif', '8.gif', '9.gif', '10.gif',
        '11.gif', '12.gif', '13.gif', '14.gif', '15.gif', '16.gif', '17.gif', '18.gif', '19.gif', '20.gif',
        '21.gif', '22.gif', '23.gif', '24.gif'
    ];

    //config for syntaxHighlight. 
    CKEDITOR.config.syntaxhighlight_hideGutter = false;
    CKEDITOR.config.syntaxhighlight_hideControls = false;
    CKEDITOR.config.syntaxhighlight_collapse = false;
    CKEDITOR.config.syntaxhighlight_codeTitle = 'code'; // default ''
    CKEDITOR.config.syntaxhighlight_showColumns = true;
    CKEDITOR.config.syntaxhighlight_noWrap = true;
    CKEDITOR.config.syntaxhighlight_firstLine = 0; // default 0
    CKEDITOR.config.syntaxhighlight_highlight = null;
    //CKEDITOR.config.syntaxhighlight_lang = 'bash', 'shell', 'cpp', 'c', 'c#', 'c-sharp', 'csharp', 'css', 'java', 'js', 'jscript', 'javascript', 'text', 'plain', 'powershell',
    //'ps', 'py', 'python', 'sql', 'vb', 'vbnet', 'xml', 'xhtml', 'xslt', 'html'; // default null
    //CKEDITOR.config.syntaxhighlight_code = ''; // default '
};
