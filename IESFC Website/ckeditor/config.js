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
    config.syntaxhighlight_hideGutter = false;
    config.syntaxhighlight_hideControls = false;
    config.syntaxhighlight_collapse = false;
    config.syntaxhighlight_codeTitle = 'code'; // default ''
    config.syntaxhighlight_showColumns = true;
    config.syntaxhighlight_noWrap = false;
    config.syntaxhighlight_firstLine = 0; // default 0
    config.syntaxhighlight_highlight = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 79];
    //CKEDITOR.config.syntaxhighlight_lang = 'bash', 'shell', 'cpp', 'c', 'c#', 'c-sharp', 'csharp', 'css', 'java', 'js', 'jscript', 'javascript', 'text', 'plain', 'powershell',
    //'ps', 'py', 'python', 'sql', 'vb', 'vbnet', 'xml', 'xhtml', 'xslt', 'html'; // default null
    //CKEDITOR.config.syntaxhighlight_code = ''; // default '
};
