@echo off
setlocal

rem doxygen -g swaf.doxy
doxygen -u swaf.doxy

doxygen -l layout.xml

doxygen -w html header.html footer.html style.css
doxygen -w latex header.tex footer.tex style.tex
doxygen -w rtf rtfstyle.cfg
doxygen -e rtf rtfextensions.cfg

endlocal
echo on
